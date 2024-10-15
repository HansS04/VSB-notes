### Jak se obecně počítá časová složitost algoritmu?

Časová složitost algoritmu se určuje analýzou toho, jak se počet operací (výpočetní čas) zvyšuje v závislosti na velikosti vstupu. To se vyjadřuje pomocí **asymptotické notace**, nejčastěji **Big-O notace** O(f(n))O(f(n))O(f(n)), která ukazuje, jak rychle roste počet operací, když se velikost vstupu (označená jako nnn) zvětšuje.

#### 1. **Analyzování základních kroků**

- **Počet základních operací** (přiřazení, sčítání, násobení, porovnání, atd.) je klíčem k analýze časové složitosti.
- Každá operace má konstantní časovou složitost O(1)O(1)O(1), což znamená, že její čas nezávisí na velikosti vstupu.

#### 2. **Identifikace smyček**

- **Lineární smyčky** (`for`, `while`) běžící od 1 do nnn mají složitost O(n)O(n)O(n).
    - Příklad: Smyčka jako `for (int i = 0; i < n; i++)` běží nnn-krát, takže složitost je O(n)O(n)O(n).
- **Vnořené smyčky** se sčítají: Pokud máte vnořenou smyčku, složitost se násobí.
    - Příklad: Smyčka ve smyčce, kde každá z nich běží nnn-krát, má složitost O(n2)O(n^2)O(n2).

#### 3. **Rekurze**

- **Rekurzivní algoritmy** se analyzují rozpisem volání, tzv. **rekurzivní rovnice**.
    - Pokud se funkce volá nnn-krát (např. pro faktoriál), složitost je O(n)O(n)O(n).
    - U složitějších rekurzivních algoritmů jako je **Merge Sort** se složitost určuje pomocí Masterovy věty, kde složitost závisí na počtu rekurzivních volání a velikosti problému při každém dělení.

---

### Typy časové složitosti

#### 1. **Konstantní čas – O(1)O(1)O(1)**

- Algoritmus vždy provede stejný počet operací, bez ohledu na velikost vstupu.
- Příklad: Přístup k prvku pole pomocí indexu (např. `arr[i]`).

#### 2. **Lineární čas – O(n)O(n)O(n)**

- Počet operací roste přímo úměrně s velikostí vstupu.
- Příklad: Procházení pole o velikosti nnn.
    - Algoritmus, který zpracuje každý prvek jednou (např. lineární vyhledávání), má složitost O(n)O(n)O(n).

#### 3. **Kvadratický čas – O(n2)O(n^2)O(n2)**

- Počet operací roste kvadraticky s velikostí vstupu.
- Příklad: Algoritmus s vnořenými smyčkami, kde každá smyčka iteruje přes nnn prvků.
    - Např. algoritmus Bubble sort, kde každá iterace prochází celý seznam znovu a znovu, má složitost O(n2)O(n^2)O(n2).

#### 4. **Logaritmický čas – O(log⁡n)O(\log n)O(logn)**

- Počet operací roste pomaleji, protože algoritmus zmenšuje vstup logaritmicky.
- Příklad: **Binární vyhledávání**, kde při každém kroku dělíte velikost vstupu na polovinu.

#### 5. **Lineárně-logaritmický čas – O(nlog⁡n)O(n \log n)O(nlogn)**

- Algoritmus kombinuje lineární a logaritmické kroky.
- Příklad: **Merge Sort** a **Quick Sort** mají složitost O(nlog⁡n)O(n \log n)O(nlogn), protože rozdělí vstupní data (logaritmické dělení) a potom je projdou (lineární slučování).

#### 6. **Exponenciální čas – O(2n)O(2^n)O(2n)**

- Algoritmus roste exponenciálně s velikostí vstupu.
- Příklad: Rekurzivní algoritmy pro některé NP-těžké problémy, jako je řešení problémů typu cestujícího obchodníka.

---

### Jak poznat, jakou složitost algoritmus má?

1. **Procházejte smyčky a rekurzi**:
    
    - Pokud máte jedinou smyčku, je složitost obvykle O(n)O(n)O(n).
    - Pokud máte smyčky vnořené, složitost se násobí – např. dvě vnořené smyčky znamenají složitost O(n2)O(n^2)O(n2).
    - Rekurzivní volání: pokud se vstup zmenšuje např. na polovinu při každém kroku, bude složitost O(log⁡n)O(\log n)O(logn) (např. binární vyhledávání).
    
1. **Porovnejte klíčové kroky algoritmu**:
    
    - Pro rekurzivní algoritmy lze použít **rekurzivní rovnice** nebo **Masterovu větu** k výpočtu složitosti.
    - Například u algoritmu **Merge Sort** se seznam rozdělí na dvě části (logaritmická část), a poté se zpracují všechny prvky (lineární část), což vede ke složitosti O(nlog⁡n)O(n \log n)O(nlogn).
    
1. **Ignorujte konstanty a menší termy**:
    
    - Big-O notace se zaměřuje na nejdominantnější složku růstu. Například, pokud má algoritmus složitost O(5n+10)O(5n + 10)O(5n+10), po odstranění konstant zůstává složitost O(n)O(n)O(n).

| **Časová složitost** |                       **Typický scénář**                       |          **Růst s `n`**           |
| :------------------: | :------------------------------------------------------------: | :-------------------------------: |
|         O(1)         |            Přístup k prvku v poli nebo hash tabulce            |             Konstanta             |
|         O(n)         |            Procházení seznamu, lineární vyhledávání            |           Lineární růst           |
|     O(n \log n)      |         Efektivní třídění, jako Merge Sort, Quick Sort         | Mírně rychlejší než      O($n^2$) |
|       O($n^2$)       |       Vnořené smyčky, kvadratické třídění (Bubble Sort)        |         Kvadratický růst          |
|       O($2^n$)       | Exponenciální algoritmy (např. problém cestujícího obchodníka) |        Exponenciální růst         |
|    **O(\log n)**     |        Dělení problému na poloviny, binární vyhledávání        |         Logaritmický růst         |
