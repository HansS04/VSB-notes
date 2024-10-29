# Gaussova eliminační metoda

Gaussova eliminační metoda je základní numerická metoda pro řešení soustav lineárních rovnic. Funguje tak, že postupně eliminuje proměnné z rovnic soustavy, čímž ji transformuje na trojúhelníkovou nebo schodovitou matici. Po dosažení této formy lze snadno použít zpětnou substituci a najít řešení.

---

## Popis algoritmu

Algoritmus přijímá matici AAA reprezentující soustavu rovnic Ax=bAx = bAx=b, kde bbb je vektor pravých stran. Cílem algoritmu je modifikovat matici AAA a vektor bbb tak, aby je bylo možné vyřešit zpětnou substitucí.

### Krok za krokem

1. **Výběr pivotu**:
    
    - Pro každý sloupec algoritmus vybírá řádek s největší absolutní hodnotou prvku ve sloupci (pivot) a přesune ho nahoru, čímž se minimalizují chyby způsobené dělením malými čísly.
    - Pokud je pivot menší než malá hodnota ϵ\epsilonϵ (předdefinovaná jako 1e-9), znamená to, že matice má nekonečně mnoho řešení nebo je nesingulární.
1. **Normalizace pivotního řádku**:
    
    - Vybraný pivotní řádek se vydělí hodnotou pivotu tak, aby se hodnota na diagonále stala roven 1. Tím se dosáhne normalizace.
3. **Eliminace prvků pod pivotem**:
    
    - Všechny řádky pod pivotním řádkem jsou upraveny tak, aby prvky ve sloupci pod pivotem byly nulové.
4. **Zpětná substituce**:
    
    - Jakmile je matice v horní trojúhelníkové formě, řeší se výsledky zpětně od posledního řádku k prvnímu.


---

## Implementace v C++

Tento kód implementuje Gaussovu eliminační metodu v C++ pro řešení soustav lineárních rovnic.

### Kódová sekce `readMatrix` a `readVector`


```cpp
vector<vector<double>> readMatrix(); vector<double> readVector();
```

Tyto funkce čtou matici a vektor z uživatelského vstupu.

- **`readMatrix`**: Čte celou matici řádek po řádku a ukládá ji jako vektor vektorů `matrix`.
- **`readVector`**: Čte vektor pravých stran `b` pro soustavu rovnic.

### Kódová sekce `gaussElimination`

```cpp
`vector<double> gaussElimination(vector<vector<double>> A, vector<double> b);`
```

### 1. **Inicializace a proměnné**

```cpp
`int n = A.size();`
```

- `n` je velikost matice AAA, která odpovídá počtu rovnic a proměnných.
- `A` je čtvercová matice koeficientů soustavy, a `b` je vektor pravých stran rovnic.

---

### 2. **Hledání a výběr pivotu**

```cpp
int pivot = i;

for (int j = i + 1; j < n; j++) 
{    
	if (fabs(A[j][i]) > fabs(A[pivot][i])) { pivot = j; } 
}
```

- Pro každý sloupec hledáme pivot, což je řádek s největší absolutní hodnotou v daném sloupci. Toto minimalizuje chyby způsobené dělením malými čísly (stabilizuje algoritmus).
- `fabs(A[j][i])` porovnává hodnoty v daném sloupci, přičemž vybírá tu největší jako pivotní hodnotu.

---

### 3. **Kontrola, zda je pivot dostatečně velký**

```cpp
`if (fabs(A[pivot][i]) < EPSILON) 
{     
	cout << "Nekonecne mnoho reseni." << endl;     
	return {}; 
}`
```

- Pokud je pivot menší než zadaná tolerance `EPSILON` (1e-9), matice pravděpodobně nemá jediné řešení (může mít nekonečně mnoho řešení nebo může být nesingulární).
- V tomto případě se vypíše hlášení o nejednoznačnosti řešení a funkce vrací prázdný vektor.

---

### 4. **Prohození řádků**

```cpp
if (fabs(A[pivot][i]) < EPSILON) 
{     
	swap(A[i], A[pivot]); swap(b[i], b[pivot]);
}
```

- Pivotní řádek se prohodí s aktuálním řádkem, aby se pivot přesunul do diagonálního prvku matice AAA.
- Rovněž se prohodí hodnoty vektoru bbb odpovídající řádkům.

---

### 5. **Normalizace pivotního řádku**

```cpp
double pivotValue = A[i][i]; 

for (int j = i; j < n; j++) 
{     
	A[i][j] /= pivotValue; 
} 
b[i] /= pivotValue;
```

- Tento krok normalizuje pivotní řádek tak, aby hodnota na diagonále (pivot) byla rovna 1.
- Všechny hodnoty v řádku se dělí `pivotValue`, včetně hodnoty ve vektoru bbb, aby nedošlo k narušení rovnosti.

---

### 6. **Eliminace prvků pod pivotem**

```cpp
for (int j = i + 1; j < n; j++) 
{     
	double factor = A[j][i];     
	for (int k = i; k < n; k++) 
	{         
		A[j][k] -= factor * A[i][k];    
	}     
	b[j] -= factor * b[i]; 
}
```

- Nyní upravujeme všechny řádky pod pivotem.
    - `factor` představuje hodnotu, která násobí pivotní řádek, aby se hodnota ve sloupci pod pivotem stala nulovou.
    - Každý prvek ve spodním řádku se upraví odečtením hodnoty z pivotního řádku, čímž se vynuluje hodnota pod pivotem v aktuálním sloupci.

---

### 7. **Zpětná substituce**

```cpp
vector<double> x(n); 

for (int i = n - 1; i >= 0; i--) 
{     
	x[i] = b[i];     
	for (int j = i + 1; j < n; j++) 
	{         
		x[i] -= A[i][j] * x[j];     
	} 
}
```

- Jakmile je matice převedena do horní trojúhelníkové podoby, řešíme systém pomocí zpětné substituce.
    - Řešení začíná od poslední rovnice, kde x[i]=b[i]x[i] = b[i]x[i]=b[i], a postupuje zpět nahoru.
    - Upravujeme každý prvek vektoru xxx tak, aby bral v úvahu již vypočtené hodnoty nad ním.

---

### 8. **Vrácení výsledku**

```cpp
return x;
```

- Výsledkem je vektor `x`, který obsahuje řešení soustavy rovnic. 

---

### Shrnutí algoritmu

1. **Výběr pivotu**: Vybere se řádek s největší absolutní hodnotou ve sloupci a nastaví se jako pivot.
2. **Normalizace pivotního řádku**: Pivotní hodnota se nastaví na 1 vydělením celého řádku.
3. **Eliminace**: Hodnoty pod pivotem v daném sloupci se vynulují odečtením násobku pivotního řádku.
4. **Zpětná substituce**: Výsledky jsou vypočítány od spodního řádku směrem nahoru.

### Časová složitost

- Časová složitost tohoto algoritmu je O(n3)O(n^3)O(n3), protože každá eliminace vyžaduje průchod přes všechny sloupce v každém kroku (průběžné dělení a úpravy).

## Kompletní C++ kód

```cpp
#include <iostream>
#include <vector>
#include <sstream>
#include <iomanip>
#include <cmath>

using namespace std;

const double EPSILON = 1e-9;

vector<vector<double>> readMatrix() {
    vector<vector<double>> matrix;
    string line;

    while (getline(cin, line) && !line.empty()) {
        vector<double> row;
        istringstream iss(line);
        double value;
        while (iss >> value) {
            row.push_back(value);
        }
        matrix.push_back(row);
    }

    return matrix;
}

vector<double> readVector() {
    vector<double> vec;
    string line;

    getline(cin, line);
    istringstream iss(line);
    double value;
    while (iss >> value) {
        vec.push_back(value);
    }

    return vec;
}

vector<double> gaussElimination(vector<vector<double>> A, vector<double> b) {
    int n = A.size();

    for (int i = 0; i < n; i++) {
        int pivot = i;
        for (int j = i + 1; j < n; j++) {
            if (fabs(A[j][i]) > fabs(A[pivot][i])) {
                pivot = j;
            }
        }

        if (fabs(A[pivot][i]) < EPSILON) {
            cout << "Nekonecne mnoho reseni." << endl;
            return {};
        }

        swap(A[i], A[pivot]);
        swap(b[i], b[pivot]);

        double pivotValue = A[i][i];
        for (int j = i; j < n; j++) {
            A[i][j] /= pivotValue;
        }
        b[i] /= pivotValue;

        for (int j = i + 1; j < n; j++) {
            double factor = A[j][i];
            for (int k = i; k < n; k++) {
                A[j][k] -= factor * A[i][k];
            }
            b[j] -= factor * b[i];
        }
    }

    vector<double> x(n);
    for (int i = n - 1; i >= 0; i--) {
        x[i] = b[i];
        for (int j = i + 1; j < n; j++) {
            x[i] -= A[i][j] * x[j];
        }
    }

    return x;
}

int main() {
    vector<vector<double>> matrix = readMatrix();
    vector<double> vec = readVector();

    vector<double> solution = gaussElimination(matrix, vec);

    if (!solution.empty()) {
        for (const auto& x : solution) {
            cout << setw(5) << fixed << setprecision(3) << x << " ";
        }
        cout << endl;
    }

    return 0;
}

```