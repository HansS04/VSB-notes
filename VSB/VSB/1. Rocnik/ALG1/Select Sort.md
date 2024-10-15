#### Jak funguje Select Sort:

Select sort (výběrové třídění) pracuje tak, že postupně vybírá nejmenší prvek z dosud netříděné části pole a vkládá jej na správné místo. Každý průchod polem tedy najde nejmenší prvek a umístí jej na začátek.

- Algoritmus začíná prvním prvkem pole, který považuje za nejmenší (`min`).
- Prochází zbývající prvky a porovnává je s hodnotou uloženou v proměnné `min`. Pokud najde menší prvek, aktualizuje `min`.
- Na konci každého průchodu vymění nejmenší nalezený prvek s aktuální pozicí.
- Tento proces se opakuje pro každý prvek pole, čímž se postupně vytváří seřazené pole.

Například pro pole `[64, 25, 12, 22, 11]`:

- **Krok 1:** Algoritmus začne u prvního prvku (`64`) a najde nejmenší prvek (`11`), vymění jej s prvním prvkem → `[11, 25, 12, 22, 64]`.
- **Krok 2:** Pokračuje s druhým prvkem (`25`), najde nejmenší prvek (`12`), vymění jej → `[11, 12, 25, 22, 64]`.
- **Krok 3:** Nalezne nejmenší prvek ve zbývajícím poli (`22`) a vymění jej → `[11, 12, 22, 25, 64]`.

Pole je nyní seřazeno.

#### Časová složitost:

- [[Časová složitost algoritmu]]

Časová složitost Select sort je v nejlepším i nejhorším případě **O(n²)**, protože algoritmus vždy prochází celé pole, aby našel nejmenší prvek, i když už může být seřazené.

#### Proč je časová složitost O(n²)?

- Algoritmus obsahuje dva zanořené cykly: vnější cyklus prochází každý prvek pole, zatímco vnitřní cyklus prochází zbývající prvky a hledá nejmenší hodnotu. To vede k počtu operací úměrnému n² v nejhorším i nejlepším případě.

## Příklad:
```cpp
void selectSort(int* p, int N)
{
    for (int i = 0; i < N - 1; i++)
    {
        int min = i; // Předpokládá, že nejmenší prvek je na pozici i
        for (int j = i + 1; j < N; j++)
        {
            if (p[j] < p[min]) // Pokud najde menší prvek, aktualizuje index min
            {
                min = j;
            }
        }
        // Vymění nejmenší prvek s prvkem na pozici i
        int temp = p[min];
        p[min] = p[i];
        p[i] = temp;
    }
}

int main()
{
    int arr[] = {64, 25, 12, 22, 11};
    int N = sizeof(arr)/sizeof(arr[0]);

    selectSort(arr, N);

    cout << "Seřazené pole: ";
    for (int i = 0; i < N; i++)
    {
        cout << arr[i] << " ";
    }

    return 0;
}

```