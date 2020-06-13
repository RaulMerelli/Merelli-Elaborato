# Merelli-Elaborato
Elaborato creato per l'esame di maturità 2020

## Come compilare
Il progetto è stato creato con ASP.NET Core 2.2, e fa uso di Entity Framework ed SQLite per i database.
Per una corretta compilazione sono anche necessarie due specifiche librerie per poter aprire i file, una  per i file PCX e una per i TGA.
Quella per i file .PCX è una mia creazione e può essere trovata all'indirizzo
github.com/RaulMerelli/Merelli-PCX-Importer
Non è necessario compilare come dll ma avere il file .cs incluso nel progetto.
Per i file .TGA la liberia richiesta è questa e necessita di essere inclusa come .Dll:
https://www.codeproject.com/Articles/31702/NET-Targa-Image-Reader
La libreria in sè non è perfetta e richiede un fix per certi tipi di immagini, che si può trovare nei commenti dello stesso post.

## Versione pubblicata
A questo indirizzo è disponibile una versione di test del servizio:
www.raulm.somee.com
