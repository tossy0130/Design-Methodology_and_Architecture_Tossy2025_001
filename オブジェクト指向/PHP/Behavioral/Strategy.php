<?php 

/*
・Strategy（ストラテジー）パターン

アルゴリズムを切り替えられるようにする。

*/

interface PaymentStrategy {
    public function pay(int $amount): void;
}

class CreditCardPayment implements PaymentStrategy {
    public function pay(int $amount): void {
        print "Paid {$amount} CreditCardPaymen \n";
    }
}

class PayPalPayment implements PaymentStrategy {
    public function pay(int $amount): void {
        print "paid {$amount} PayPalPayment \n";
    }
}

class PaymentContext {
    private PaymentStrategy $strategy;

    public function __construct(PaymentStrategy $strategy) {
        $this->strategy = $strategy;
    }

    public function pay(int $amount): void {
        $this->strategy->pay($amount);
    }
}

// ****** 実行 *******
$context = new PaymentContext(new PayPalPayment());
$context->pay(500);


?>