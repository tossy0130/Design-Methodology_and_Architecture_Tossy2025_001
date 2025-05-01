<?php 

/*
識別子によって区別され、ライフサイクル全体にわたって一貫性を保つオブジェクト。
例：ユーザー、注文など。
*/

final class User 
{   
    // コンストラクタ
    public function __construct(
        private readonly string $id,
        private string $name
    ) {}
    
    // リネーム function
    public function rename(string $changeName)
    {
        $this->name = $changeName;
    }

    public function getId(): string 
    {
        return $this->id;
    }
}


?>