100.75.50.64/28


| prefix | maska           | increment | uzlů |
| ------ | --------------- | --------- | ---- |
| /32    | 255.255.255.255 | 1(2na1)   | -(1) |
| /31    | 255.255.255.254 | 2(2na2)   | -(2) |
| /30    | .252            | 4         | 2    |
| /29    | .248            | 8         | 6    |
| /28    | .240            | 16        | 14   |
| /27    | .224            | 32        | 30   |
| /26    | .192            | 64        | 62   |
| /25    | .128            | 128       | 126  |
| /24    | 255.0           | 1.0       | 254  |

| prefix | maska | increment  | uzlů |
| ------ | ----- | ---------- | ---- |
| /23    | 254.0 | 2.0(2na9)  | 510  |
| /22    | 252.0 | 4.0(2na10) | 1022 |
| /21    | 248.0 | 8.0        | 2046 |
| /20    | 240.0 | 16.0       | 4094 |


![[topologie.png]]



| ID  | address     | prefix | použitelné adr. | broadcast |
| --- | ----------- | ------ | --------------- | --------- |
| S1  | 100.75.50.0 | /28    | 1 - 14          | .15       |
| S3  | .16         | /28    | 17 - 30,        | .31       |
| S2  | .32         | /28    | 30 - 46         | .47       |
| S7  | .48         | /29    | 49 - 54         | .55       |
| S4  | .56         | /30    | 57 - 58         | .59       |
| S5  | .60         | /30    | 61 - 62         | .63       |
| S6  | .64         | /30    | 65  - 56        | .67       |

![[topologie2.png]]

## CVIČENÍ:

- PŘEPSAT:

| ID  | address     | prefix | použitelné adr. | broadcast |
| --- | ----------- | ------ | --------------- | --------- |
| S1  | 100.75.50.0 | /28    | 1 - 14          | .15       |
| S3  | .16         | /28    | 17 - 30,        | .31       |
| S2  | .32         | /28    | 30 - 46         | .47       |
| S7  | .48         | /29    | 49 - 54         | .55       |
| S4  | .56         | /30    | 57 - 58         | .59       |
| S5  | .60         | /30    | 61 - 62         | .63       |
| S6  | .64         | /30    | 65  - 56        | .67       |
## Topologie 1
![[topologie1.pdf]]]