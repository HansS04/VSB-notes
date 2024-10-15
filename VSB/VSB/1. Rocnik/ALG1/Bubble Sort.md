#### Jak funguje Bubble Sort:

Bubble sort je jednoduchý třídicí algoritmus, který opakovaně prochází pole a porovnává prvky vedle sebe. Pokud je levý prvek větší než pravý, vymění je. Tento proces se opakuje, dokud nejsou všechny prvky správně seřazeny.

- Algoritmus prochází pole od začátku do konce, při každé iteraci postupně "bublají" větší prvky směrem k poslednímu indexu.
- V každé iteraci je poslední prvek již na správné pozici, a proto se s každým průchodem pole zmenšuje rozsah porovnávaných prvků.

Například pro pole `[4, 2, 3, 1]`:

- **Krok 1:** Porovná `4` a `2`, vymění → `[2, 4, 3, 1]`. Porovná `4` a `3`, vymění → `[2, 3, 4, 1]`. Porovná `4` a `1`, vymění → `[2, 3, 1, 4]`.
- **Krok 2:** Porovná `2` a `3`, bez výměny. Porovná `3` a `1`, vymění → `[2, 1, 3, 4]`.
- **Krok 3:** Porovná `2` a `1`, vymění → `[1, 2, 3, 4]`.

Pole je nyní seřazeno.

#### Časová složitost:

- [[Časová složitost algoritmu]]

V nejhorším případě je časová složitost algoritmu **O(n²)**, protože každý prvek se může muset posunout přes celé pole.

V nejlepším případě (když je pole již seřazeno) je časová složitost **O(n)**, pokud algoritmus používá optimalizaci, která zastaví třídění, pokud nebyly provedeny žádné výměny.

#### Proč je časová složitost O(n²)?

- Algoritmus má dva zanořené cykly: vnější cyklus běží `n-1` krát a vnitřní cyklus běží `n-i-1` krát, což v nejhorším případě způsobuje časovou složitost O(n²).

## Příklad:

```cpp
void bubbleSort(int* p, int N)
{
    for (int i = 0; i < N - 1; i++)
    {
        for (int j = 0; j < N - i - 1; j++)
        {
            if (p[j] > p[j + 1])
            {
                int temp = p[j];
                p[j] = p[j + 1];
                p[j + 1] = temp;
            }
        }
    }
}

int main()
{
    int arr[] = {64, 34, 25, 12, 22, 11, 90};
    int N = sizeof(arr)/sizeof(arr[0]);

    bubbleSort(arr, N);

    cout << "Seřazené pole: ";
    for (int i = 0; i < N; i++)
    {
        cout << arr[i] << " ";
    }

    return 0;
}
```