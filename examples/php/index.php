<?php
require __DIR__ . '/vendor/autoload.php';

use Guibranco\BancosBrasileiros\Bank;

$banks = Bank::all();
?>

<link rel="stylesheet" href="app.css">
<div class="jumbo">
    <h2>Welcome to Bancos Brasileiros PHP example!</h2>
    <p>We hope you find exactly what you're looking for in a place to stay.</p>
</div>

<div class="banks">
    <div class="results">
        <?php foreach($banks as $bank) {?>
            <li>
                <article class="bank">
                    <div class="details">
                        <h3><?php echo $bank->ShortName; ?></h3>
                        <div class="detail owner">
                            <span>Full name:</span> <?php echo $bank->LongName; ?>
                        </div>
                        <div class="detail type">
                            <span>Type:</span> <?php echo $bank->Type; ?>
                        </div>
                        <div class="detail type">
                            <span>COMPE:</span> <?php echo $bank->COMPE; ?>
                        </div>
                        <div class="detail location">
                            <span>ISPB:</span> <?php echo $bank->ISPB; ?>
                        </div>
                        <div class="detail bedrooms">
                            <span>CNPJ:</span> <?php echo $bank->Document; ?>
                        </div>
                        <div class="detail type">
                            <span>Bank bill:</span> <?php echo ($bank->Charge)? $bank->Charge: "N/A"; ?>
                        </div>
                        <div class="detail type">
                            <span>TED/DOC:</span> <?php echo ($bank->CreditDocument)? $bank->CreditDocument: "N/A"; ?>
                        </div>
                        <div class="detail type">
                            <span>PIX:</span> <?php echo ($bank->PixType)? $bank->PixType: "N/A"; ?>
                        </div>
                        <div class="detail location">
                            <span>URL: </span>
                            <?php if($bank->Url) { ?>
                                <a href="<?php echo $bank->Url; ?>"><?php echo $bank->Url; ?></a>
                            <?php } else{ ?>
                                <span>N/A</span>
                            <?php } ?>
                        </div>
                        <div class="detail type">
                            <span>Date updated:</span> <?php echo date('Y-m-d H:i:s', strtotime($bank->DateUpdated)); ?>
                        </div>
                    </div>
                </article>
            </li>
        <?php } ?>
    </div>
</div>