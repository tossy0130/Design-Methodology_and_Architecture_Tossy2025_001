<?php 

interface Coffee {
    public function cost(): int;
}

class BasicCoffee implements Coffee {
    public function cost(): int {
        return 300;
    }
}

class MilkDecorator implements Coffee {
    private Coffee $coffee;

    public function __construct(Coffee $coffee) {
        $this->coffee = $coffee;
    }

    public function cost(): int {
        return $this->coffee->cost() + 100;
    }
}

// ****** 使用 ******
$coffee = new MilkDecorator(new BasicCoffee());
print $coffee->cost(); // 出力　400

?>