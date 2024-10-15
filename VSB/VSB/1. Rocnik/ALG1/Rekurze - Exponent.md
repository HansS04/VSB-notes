#### Jak funguje rekurze:

Rekurzivní algoritmus pro výpočet mocniny počítá výsledek tak, že se volá znovu a znovu, dokud nedosáhne základního případu (exponent = 0). Každé volání počítá mocninu menšího exponentu a násobí základním číslem, dokud se nevrátí zpět k původnímu volání.

Například pro `base^exp`:

- `exp(2, 4)` vrátí `2 * exp(2, 3)`
- `exp(2, 3)` vrátí `2 * exp(2, 2)`
- `exp(2, 2)` vrátí `2 * exp(2, 1)`
- `exp(2, 1)` vrátí `2 * exp(2, 0)`
- `exp(2, 0)` vrátí `1` (základní případ)

#### Časová složitost:

- [[Časová složitost algoritmu]]

Časová složitost tohoto algoritmu je **O(n)**.

#### Proč je časová složitost O(n)?

- Algoritmus volá sám sebe tolikrát, kolik je hodnota exponentu `n`, přičemž každá rekurze snižuje exponent o 1, dokud není dosaženo základního případu `exp = 0`.
- Každé volání funkce zabere konstantní čas O(1), ale jelikož se rekurze volá `n`-krát (pro každé číslo od `n` do 0), celková časová složitost je O(n).

## Příklad:

```cpp
int main()
{
    int base = 2;
    int exp = 10;
    int result = power(base, exp);
    cout << result << endl;
    system("pause");
    return 0;
}

int power(int base, int exp)
{
    if (exp == 0)
    {
        return 1;
    }
    return base * power(base, exp - 1);
}
```