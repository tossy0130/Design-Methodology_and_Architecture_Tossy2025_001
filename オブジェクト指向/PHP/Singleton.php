<?php
class Singleton {
    /*
        Singleton（シングルトン）
        ・インスタンスを1つだけ生成し、それを再利用する。
    */
    private static ?Singleton $instance = null;

    // 外部からのインスタンス化を禁止
    private function __construct() {}

    public static function getInstance(): Singleton {
        if(self::$instance === null) {
            self::$instance = new Singleton();
        }
        return self::$instance;
    }

    public function Hello() {
        print "ハロー Singleton";
    }

}

// 使用
$obj = Singleton::getInstance();
$obj->Hello();

?>