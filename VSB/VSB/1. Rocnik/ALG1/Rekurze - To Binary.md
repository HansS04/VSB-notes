#### Jak funguje rekurze:

Rekurzivní algoritmus pro převod čísla na binární podobu postupně dělí číslo `number` dvěma, dokud nedosáhne základního případu (kdy `number` je menší nebo rovno 1). Při každém dělení algoritmus ukládá zbytek a na konci vytiskne binární reprezentaci zleva doprava.

Například pro číslo `6`:

- `toBinary(6)` zavolá `toBinary(3)` a vytiskne zbytek `0`
- `toBinary(3)` zavolá `toBinary(1)` a vytiskne zbytek `1`
- `toBinary(1)` vytiskne `1` (základní případ)

Celkový výsledek bude `110`, což je binární reprezentace čísla `6`.

#### Časová složitost:

- [[Časová složitost algoritmu]]

Časová složitost tohoto algoritmu je **O(log n)**.

#### Proč je časová složitost O(log n)?

- Algoritmus volá sám sebe dokud není číslo `number` menší nebo rovno 1. S každým voláním se číslo zmenšuje dělením dvěma.
- Jelikož každé dělení sníží hodnotu `number` na polovinu, počet rekurzivních volání je úměrný počtu bitů potřebných k reprezentaci čísla, což je přibližně logaritmické.

## Příklad:

```cpp
bool toBinary(int number)
{
    int remainder;
    if (number <= 1)
    {
        cout << number;
        return 0;
    }
    remainder = number % 2;
    toBinary(number / 2);
    cout << remainder;
}

int main()
{
    int number;
    cout << "Zadejte cislo:" << endl;
    cin >> number;
    if (cin.fail() || number < 0)
    {
        cout << "Nespravny vstup." << endl;
    }
    else
    {
        toBinary(number);
        cout << endl;
    }
    system("pause");
    return 0;
}
```