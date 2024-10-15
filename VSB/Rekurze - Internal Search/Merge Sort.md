#### Jak funguje rekurze:

Rekurzivní algoritmus pro **interní vyhledávání** (typicky binární vyhledávání) funguje tak, že opakovaně dělí pole na poloviny, dokud nenajde hledanou hodnotu `v`, nebo dokud nemůže potvrdit, že hodnota v poli není.

Prvky v poli musí být seřazeny. Algoritmus kontroluje střední prvek pole `M`. Pokud se hodnota na indexu `M` rovná hledané hodnotě `v`, vyhledávání skončí a vrátí se `true`. Pokud je hledaná hodnota menší, vyhledávání pokračuje na levé straně pole, pokud je větší, na pravé straně.

Například pro `v = 7` v poli `[1, 3, 5, 7, 9]`:

- **Krok 1:** Pole `[1, 3, 5, 7, 9]`, kontroluje střední prvek: `5`. Jelikož `7 > 5`, hledání pokračuje v pravé části `[7, 9]`.
- **Krok 2:** Pole `[7, 9]`, kontroluje střední prvek: `7`. Jelikož `7 == 7`, vrací se `true`.

#### Časová složitost:

- [[Časová složitost algoritmu]]

Časová složitost tohoto algoritmu je **O(log n)**.

#### Proč je časová složitost O(log n)?

- S každým rekurzivním voláním se vyhledávané pole zmenší na polovinu (buď levá, nebo pravá část), což vede k logaritmickému poklesu počtu prvků, které je nutné prohledat.
- Protože počet operací se sníží na polovinu s každým voláním, časová složitost je logaritmická, tedy O(log n).

## Příklad:

```cpp
bool internalSearch(int* p, int v, int l, int r)
{
    if (l > r)
    {
        return false;
    }
    
    int M = (l + r) / 2;
    
    if (v == p[M])
    {
        return true;
    }
    else if (v < p[M])
    {
        return internalSearch(p, v, l, M - 1);
    }
    else
    {
        return internalSearch(p, v, M + 1, r);
    }
}

int main()
{
    int arr[] = {1, 3, 5, 7, 9};
    int size = sizeof(arr) / sizeof(arr[0]);
    int value = 7;
    
    if (internalSearch(arr, value, 0, size - 1))
    {
        cout << "Hodnota nalezena." << endl;
    }
    else
    {
        cout << "Hodnota nebyla nalezena." << endl;
    }

    return 0;
}

```