## Základní příkazy pro správu síťového rozhraní

### `ifconfig`

- **Popis**: Příkaz zobrazí aktuální konfiguraci síťových rozhraní.
- **Použití**:
    `ifconfig`
- **Více zde:**
	-[man ifconfig](https://man7.org/linux/man-pages/man8/ifconfig.8.html)
	
#### Deaktivace rozhraní:

- **Příkaz**:
    `sudo ifconfig eth1 down`
    
- **Popis**: Tento příkaz deaktivuje síťové rozhraní `eth1`.

#### Zobrazení rozhraní:

- **Příkaz**:
    `sudo ifconfig eth1`
    
- **Popis**: Zobrazí detaily o síťovém rozhraní `eth1`.

---

## Správa směrování

### `route -n`

- **Popis**: Zobrazí směrovací tabulku.
- **Použití**:
    `route -n`
    

### Přidání nové trasy

- **Příkaz**:
    `route add 10.0.0.0 netmask 255.255.0.0 gw 10.0.1.30`
    
- **Popis**: Přidá trasu do sítě `10.0.0.0/16` s bránou `10.0.1.30`.

---

## Správa síťových rozhraní pomocí `ip`

### `ip link`

- **Popis**: Zobrazuje stav síťových rozhraní.
- **Použití**:
    `ip link`
    

#### Deaktivace rozhraní

- **Příkaz**:
    `ip link set dev eth1 down`
    
- **Popis**: Deaktivuje síťové rozhraní `eth1`.

### `ip addr`

- **Popis**: Zobrazuje IP adresy přiřazené k síťovým rozhraním.
- **Použití**:
    `ip addr`
    

---

## Diagnostické nástroje

### `nslookup`

- **Popis**: Provede dotaz na DNS server.
- **Použití**:
    `nslookup vsb.cz`
    

### `tracepath`

- **Popis**: Zjišťuje trasu paketu k cílové IP adrese nebo doméně.
- **Parametry**:
    - `-n`: Zobrazí IP adresy bez DNS rozlišení.
    - `-4`: Použije IPv4.
    - `-6`: Použije IPv6.

---

# Práce se switchem

### Zapojeni v realite:
![[zapojeni.jpg]]

### Zobrazení stavu rozhraní na switchi

- **Příkaz**:
    `ip link show dev eth1`
    
- **Popis**: Zobrazuje stav konkrétního rozhraní `eth1`.

### Přiřazení IP adresy na rozhraní

- **Příkaz**:
    `ip a a 10.0.1.<číslo_modulu>/24 dev eth1`
    
- **Popis**: Přiřadí IP adresu síťovému rozhraní `eth1`.

### Minicom

- **Popis**: Program pro komunikaci s konzolí přes sériový port.

### Zobrazení sousedů CDP (Cisco Discovery Protocol)

- **Příkaz**  
    `do show cdp neigh`
    
- **Popis**: Zobrazí informace o sousedních zařízení

## Počítání IP adres

- #### [[ip-address]]
