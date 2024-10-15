#### Jak funguje rekurze:

Rekurzivní algoritmus pro výpočet faktoriálu počítá výsledek tak, že se volá znovu a znovu, dokud nedosáhne základního případu (n = 1). Každý volaný případ spočítá faktoriál menšího čísla a vrací výsledek až do původního volání.

Například:

- `fac(4)` vrátí `4 * fac(3)`
- `fac(3)` vrátí `3 * fac(2)`
- `fac(2)` vrátí `2 * fac(1)`
- `fac(1)` vrátí `1` (základní případ)

#### Časová složitost:
- [[Časová složitost algoritmu]]

Časová složitost tohoto algoritmu je **O(n)**.

#### Proč je časová složitost O(n)?

- Algoritmus volá sám sebe n-krát, přičemž se s každou iterací snižuje hodnota `n` o 1, dokud není dosaženo základního případu `n = 1`.
- Každé volání funkce zabere konstantní čas O(1)O(1)O(1), ale jelikož rekurze probíhá n-krát (pro každé číslo od `n` do 1), celková časová složitost je O(n)O(n)O(n).

## Příklad:

```cpp
int main()
{
    int n = 10;
    int result = fac(n);
    cout << result << endl;
    system("pause");
    return 0;
}

int fac(int n)
{
    if (n <= 1)
    {
        return 1;
    }
    return (n * fac(n - 1));
}

```

