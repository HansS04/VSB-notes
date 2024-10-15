#### Jak funguje Insert Sort:

Insert sort (vkládací třídění) pracuje tak, že postupně vybírá prvky z pole (počínaje druhým) a vkládá je na správné místo mezi již seřazené prvky na levé straně pole. Každý vybraný prvek se porovnává s předchozími a pokud je menší, posune se na správnou pozici.

- Algoritmus si vybere druhý prvek v poli a porovná jej s prvním. Pokud je druhý prvek menší, vymění je.
- Pokračuje s dalším prvkem, který porovnává se všemi předchozími, dokud nenajde správnou pozici.
- Tento postup se opakuje, dokud nejsou všechny prvky seřazeny.

Například pro pole `[5, 2, 4, 6, 1, 3]`:

- **Krok 1:** Vybere `2` a porovná s `5`, vymění → `[2, 5, 4, 6, 1, 3]`.
- **Krok 2:** Vybere `4` a porovná s `5`, vymění → `[2, 4, 5, 6, 1, 3]`.
- **Krok 3:** Vybere `6`, bez výměny.
- **Krok 4:** Vybere `1`, posune všechny větší prvky doprava a vloží `1` na začátek → `[1, 2, 4, 5, 6, 3]`.
- **Krok 5:** Vybere `3`, porovná a vloží na správné místo → `[1, 2, 3, 4, 5, 6]`.

#### Časová složitost:

- [[Časová složitost algoritmu]]

V nejlepším případě (když je pole již seřazeno) má Insert sort časovou složitost **O(n)**.

V nejhorším případě (když je pole seřazeno opačně) má algoritmus časovou složitost **O(n²)**, protože pro každý prvek musí procházet a porovnávat s většinou již seřazených prvků.

#### Proč je časová složitost O(n²)?

- Algoritmus má vnořený cyklus: vnější cyklus prochází každý prvek, zatímco vnitřní cyklus porovnává každý prvek s předchozími prvky. V nejhorším případě může každé porovnání vyžadovat až `n` kroků, což vede ke kvadratické složitosti O(n²).

## Příklad:

```cpp
void insertSort(int* p, int N)
{
    for (int i = 1; i < N; i++)
    {
        int key = p[i];
        int j = i - 1;
        
        while (j >= 0 && p[j] > key)
        {
            p[j + 1] = p[j];
            j--;
        }
        
        p[j + 1] = key;
    }
}

int main()
{
    int arr[] = {12, 11, 13, 5, 6};
    int N = sizeof(arr)/sizeof(arr[0]);

    insertSort(arr, N);

    cout << "Seřazené pole: ";
    for (int i = 0; i < N; i++)
    {
        cout << arr[i] << " ";
    }

    return 0;
}

```