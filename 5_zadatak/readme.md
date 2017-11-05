#Pitanje 1
Izvodenje je trajalo 5.0006503 sekunde

#Pitanje 2
Operacije su se izvodile na 1 dretvi.

#Pitanje 3
Paralelno izvodenje je trajalo 1.0208432 sekunde

#Pitanje 4
Operacije su se izvodile na 5 dretvi (1,5,3,6,4)

#Pitanje 5
Primjerice imamo dvije dretve, od kojih jedna poziva funkciju inkrementiranja
dok druga poziva funkciju dekrementiranja. Ukoliko obje pročitaju vrijednost neke varijable (inicijalna vrijednost = 0)
nad kojom se funkcije inkrementiranja/dekrementiranja izvode, te potom prva dretva izvede 
povećanje za 1, dok druga izvade smanjenje za 1. Te tada prva dretva spremi varijablu (kao vrijednost 1)
,zatim i druga dretva izvede operaciju spremanja (varijabla = -1). Operacija spremanja druge dretve je prepisala vrijednost
varijable koju je spremila prva dretva. Takvo ponašanje može dovesti do pogrešaka u programu.