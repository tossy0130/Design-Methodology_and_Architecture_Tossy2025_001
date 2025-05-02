<?php

/*

●構造パターン

・アダプター パターン
複数オブジェクトの構造を整理・統一します。

*/

interface Target {
    public function request(): string;
}

class Adaptee  {
    public function specificRequest(): string {
        return "Specific Request";
    }
}

class Adapter implements Target {
    private Adapter $adapter;

    public function __construct(Adaptee $adaptee) {
        $this->adapter = $adaptee;
    }

    public function request(): string {
        return $this->adaptee->specificRequest();
    }
}

/* ***** 使用 ***** */
$adapter = new Adapter(new Adaptee());
print $adapter->request();

?>