#!/usr/bin/env python3
"""
validate_bancos.py
==================
Valida o arquivo data/bancos.json contra o JSON Schema definido em
bancos.schema.json.

Uso:
    python validate_bancos.py [--data PATH] [--schema PATH] [--strict]

Dependências:
    pip install jsonschema

Retorna:
    0  – validação OK
    1  – erros de validação encontrados
    2  – erro de I/O ou argumento inválido
"""

import argparse
import json
import sys
from pathlib import Path
from typing import Any

try:
    import jsonschema
    from jsonschema import Draft7Validator, FormatChecker
except ImportError:
    print(
        "❌ Dependência ausente: instale com  pip install jsonschema",
        file=sys.stderr,
    )
    sys.exit(2)


# ---------------------------------------------------------------------------
# helpers
# ---------------------------------------------------------------------------

RESET = "\033[0m"
RED = "\033[31m"
GREEN = "\033[32m"
YELLOW = "\033[33m"
CYAN = "\033[36m"
BOLD = "\033[1m"


def _color(text: str, code: str, use_color: bool) -> str:
    return f"{code}{text}{RESET}" if use_color else text


def load_json(path: Path) -> Any:
    try:
        # utf-8-sig descarta o BOM silenciosamente quando presente;
        # em arquivos sem BOM o comportamento é idêntico ao utf-8.
        with path.open(encoding="utf-8-sig") as fh:
            return json.load(fh)
    except FileNotFoundError:
        print(f"❌ Arquivo não encontrado: {path}", file=sys.stderr)
        sys.exit(2)
    except json.JSONDecodeError as exc:
        print(f"❌ JSON inválido em {path}: {exc}", file=sys.stderr)
        sys.exit(2)


# ---------------------------------------------------------------------------
# validation
# ---------------------------------------------------------------------------


def validate(data_path: Path, schema_path: Path, strict: bool, use_color: bool) -> int:
    """Executa a validação e imprime o relatório. Retorna o código de saída."""

    data = load_json(data_path)
    schema = load_json(schema_path)

    validator = Draft7Validator(schema, format_checker=FormatChecker())

    # Coleta todos os erros (não para no primeiro)
    errors = sorted(validator.iter_errors(data), key=lambda e: list(e.absolute_path))

    # ---------- relatório de cabeçalho ----------
    total = len(data) if isinstance(data, list) else 1
    print(f"\n{_color('Bancos Brasileiros – Validação de Esquema', BOLD, use_color)}")
    print(f"  Arquivo  : {data_path}")
    print(f"  Schema   : {schema_path}")
    print(f"  Registros: {total}")
    print()

    if not errors:
        print(_color("✅  Todos os registros são válidos!", GREEN, use_color))
        _print_summary(data, use_color)
        return 0

    # ---------- detalhamento dos erros ----------
    print(
        _color(
            f"⚠️  {len(errors)} erro(s) de validação encontrado(s):\n", YELLOW, use_color
        )
    )

    grouped: dict[str, list[jsonschema.ValidationError]] = {}
    for err in errors:
        path_parts = list(err.absolute_path)
        # path_parts[0] é o índice do registro no array raiz
        idx = path_parts[0] if path_parts else "raiz"
        grouped.setdefault(str(idx), []).append(err)

    for idx_str, errs in grouped.items():
        # Tenta pegar identificador do registro para mensagem amigável
        try:
            record = data[int(idx_str)]
            label = record.get("COMPE", "?") + " – " + record.get("ShortName", "")
        except (ValueError, IndexError, AttributeError, TypeError):
            label = f"registro [{idx_str}]"

        print(_color(f"  Registro [{idx_str}] – {label}", CYAN, use_color))
        for err in errs:
            field = " > ".join(str(p) for p in list(err.absolute_path)[1:]) or "(raiz)"
            print(f"    {_color('campo', BOLD, use_color)}: {field}")
            print(f"    {_color('erro', RED, use_color)} : {err.message}")
            if strict and err.context:
                for ctx in err.context:
                    print(f"           {ctx.message}")
            print()

    # ---------- resumo final ----------
    ok_count = total - len(grouped)
    print(
        _color(
            f"Resumo: {ok_count}/{total} registros OK, {len(grouped)} com problema(s).",
            YELLOW,
            use_color,
        )
    )
    return 1


def _print_summary(data: list, use_color: bool) -> None:
    """Imprime estatísticas básicas do dataset."""
    if not isinstance(data, list):
        return

    pix_count = sum(1 for b in data if b.get("PixType"))
    charge_count = sum(1 for b in data if b.get("Charge"))
    types: dict[str, int] = {}
    for b in data:
        t = b.get("Type") or "Não classificado"
        types[t] = types.get(t, 0) + 1

    print()
    print(_color("  Estatísticas do dataset:", BOLD, use_color))
    print(f"    Total de instituições : {len(data)}")
    print(f"    Com Pix habilitado    : {pix_count}")
    print(f"    Com cobranças (boleto): {charge_count}")
    print(f"    Tipos distintos       : {len(types)}")
    top = sorted(types.items(), key=lambda x: -x[1])[:5]
    for name, cnt in top:
        print(f"      {cnt:>4}  {name}")
    print()


# ---------------------------------------------------------------------------
# CLI
# ---------------------------------------------------------------------------


def main() -> None:
    parser = argparse.ArgumentParser(
        description="Valida bancos.json contra o JSON Schema."
    )
    parser.add_argument(
        "--data",
        type=Path,
        default=Path("data/bancos.json"),
        help="Caminho para o arquivo de dados (padrão: data/bancos.json)",
    )
    parser.add_argument(
        "--schema",
        type=Path,
        default=Path("bancos.schema.json"),
        help="Caminho para o JSON Schema (padrão: bancos.schema.json)",
    )
    parser.add_argument(
        "--strict",
        action="store_true",
        help="Exibe contexto adicional de erros anyOf/oneOf",
    )
    parser.add_argument(
        "--no-color",
        action="store_true",
        help="Desativa cores no terminal",
    )

    args = parser.parse_args()
    use_color = not args.no_color and sys.stdout.isatty()

    exit_code = validate(args.data, args.schema, args.strict, use_color)
    sys.exit(exit_code)


if __name__ == "__main__":
    main()
