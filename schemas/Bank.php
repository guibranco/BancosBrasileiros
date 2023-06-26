<?php
namespace Guibranco\BancosBrasileiros;

use Exception;

class Bank
{
    /** @var string */
    public $COMPE;

    /** @var string */
    public $ISPB;

    /** @var string */
    public $Document;

    /** @var string */
    public $LongName;

    /** @var string */
    public $ShortName;

    /** @var string|null */
    public $Network;

    /** @var string|null */
    public $Type;

    /** @var string|null */
    public $PixType;

    /** @var bool|null */
    public $Charge;

    /** @var bool|null */
    public $CreditDocument;

    /** @var string|null */
    public $SalaryPortability;

    /** @var string[]|null */
    public $Products;

    /** @var string|null */
    public $Url;

    /** @var string|null */
    public $DateOperationStarted;

    /** @var string|null */
    public $DatePixStarted;

    /** @var DateTime|string */
    public $DateRegistered;

    /** @var DateTime|string */
    public $DateUpdated;

    public static $jsonPath = __DIR__."/../data/bancos.json";

    public static function all() {
        $file = file_get_contents(self::$jsonPath);
        if (! $file) {
            throw new Exception("Json File not found");
        }

        return json_decode(preg_replace('/[\x00-\x1F\x80-\xFF]/', '', $file));
    } 
}
