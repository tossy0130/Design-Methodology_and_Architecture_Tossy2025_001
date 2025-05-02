<?php

/*

■振る舞い パターン
・オブジェクト間の責務ややりとりに関するパターン

・Observer（オブザーバー）パターン
状態変化を複数のオブジェクトに通知。

*/

interface Observer {
    public function update(string $message): void;
}

interface Subject {
    public function attach(Observer $observer): void;
    public function notify(): void;
}

class NewsPublisher implements Subject {
    private array $observer = [];
    private string $news = "";

    public function attach(Observer $observer): void {
        $this->observers[] = $observer;
    }

    public function addNews(string $news): void {
        $this->news = $news;
        $this->notify();
    }
}

class NewsReader implements Observer {
    private string $name;

    public function __construct(string $name) {
        $this->name = $name;
    }

    public function update(string $message): void {
        print "{$this->name} 受け取ったニュース:{$message}\n";
    }
}

// *** 実行 ***
$publisher = new NewsPublisher();
$publisher->attach(new NewsReader("Tossy"));
$publisher->attach(new NewsReader("RIBON"));
$publisher->addNews("Tossy AND Ribon");

?>