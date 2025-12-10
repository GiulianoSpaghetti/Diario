🇮🇹 Made in Italy. Il primo prodotto maui ad utilizzare linq su maui nel mondo.
![Napoli-Logo](https://github.com/user-attachments/assets/ffa0d95d-2ee4-43e7-b644-d18baa1c0ed0)
![made in parco grifeo](https://github.com/user-attachments/assets/28cd34ca-a02d-47a4-8738-bde56b0f3b13)

## Diario

Un diario in maui con sqlite integrato non crittato

La differenza tra un database relazionale ed un database ad oggetti è che mysql consente di stabilire relazioni tra le entità (con l'id), mentre un database ad oggetti conserva solo l'oggetto.

## Come installare

## Su Android

[![google](https://play.google.com/intl/it_it/badges/static/images/badges/en_badge_web_generic.png)](https://play.google.com/store/apps/details?id=org.altervista.numerone.diario)

## Su windows

Basta andare nella sezione release e scegliere l'msix che più piace.
L'msix ha bisogno di un certificato, che va installato in "Computer locale" > "Persone attendibili"

Prerequisiti:

https://winstall.app/apps/Microsoft.DotNet.DesktopRuntime.10

Oppure 9 o o 8 a seconda di quello che scegliete. E' consigliabile avere l'appruntime 1.8 installato sul computer (https://winstall.app/apps/Microsoft.WindowsAppRuntime.1.8), anche se si utilizza il desktop runtime 9 o 10. Tutto da provare...

## Aggiornamenti

Per windows i package msix sono platform indepedent ed in IL, ma sono in dotnet 9 e 10, pr cui è necessario ricompilare per evitare di avere il sistema spurio in caso di nuovo dotnet framework che comunque è necessario per l'avvio del software, che se aggiornato dovrebbe impeire lo shock sulle ventolee.

## Differenze tra il software maui ed il software avalonia

Il maui ha bisogno di girare in una sandbox, invece avalonia gira coi permessi dell'utente.
Per cui su windows è meglio usare l'avalonia.

## Screenshot

![Screenshot 2025-02-01 232610](https://github.com/user-attachments/assets/36f901c7-a1ec-4705-a7a2-dbbbe26235ce)
<img width="1431" alt="2025-02-01" src="https://github.com/user-attachments/assets/fe97628b-9a42-46a8-8a6d-65634cd8bf69" />
<img width="1431" alt="2025-02-01 (9)" src="https://github.com/user-attachments/assets/f4013b37-5a1a-4774-b9d0-c429bae9091e" />
<img width="1431" alt="2025-02-01 (8)" src="https://github.com/user-attachments/assets/7c15898a-a1b0-4869-a870-7d716e6384a2" />


# Donazioni

http://numerone.altervista.org/donazioni.php
