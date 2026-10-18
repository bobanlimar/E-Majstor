## Testovi

1. **GET /api/Majstor** - Proverio sam da li se prikazuje lista majstora. Dobio sam 200 OK i sve je radilo normalno.

2. **POST /api/Majstor** - Dodao sam testnog majstora Marka Markovica. Dobio sam 201 Created, što znači da je uspesno dodat u bazu.

3. **GET /api/Majstor/1** - Proverio sam da li mogu da pronadem majstora preko njegovog ID-a. Dobio sam 200 OK i prikazali su se svi njegovi podaci.

4. **Restart Docker kontejnera** - Restartovao sam kontejner i ponovo proverio podatke. Majstor je i dalje bio sačuvan u bazi.

## Zakljucak

Svi testovi su prosli uspesno. Backend radi preko Dockera, API zahtevi funkcionišu i podaci ostaju sacuvani u SQLite bazi nakon restarta. Tokom testiranja nisam imao nikakvih problema.
