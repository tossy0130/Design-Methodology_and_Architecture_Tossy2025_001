<?php

/*
識別子を持たず、属性の集合であり、イミュータブル（不変）なオブジェクト。
例：金額、住所、日付など。
*/

final class Email
{
    public function __construct(private readonly string $value)
    {
        if(!filter_var($value, FILTER_VALIDATE_EMAIL)) {
            throw new InvalidArgumentException("Invalid email: $value");
        }
    }

    public function getValue(): string
    {
        return $this->value;
    }
}



?>