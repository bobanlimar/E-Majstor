USE e_majstor;

-- Test korisnici
INSERT INTO users (ime_prezime, email, sifra_hash, telefon, grad, uloga) VALUES
('Marko Marković', 'marko@gmail.com', 'hash_sifra_1', '0641112223', 'Beograd', 'klijent'),
('Petar Petrović', 'petar.majstor@gmail.com', 'hash_sifra_2', '0633334445', 'Beograd', 'majstor'),
('Nikola Nikolić', 'nikola.vodoinstalater@gmail.com', 'hash_sifra_3', '0655556667', 'Novi Sad', 'majstor');

-- Test majstori
INSERT INTO majstori (user_id, kategorija, opis, cena_po_satu) VALUES
(2, 'Električar', 'Iskusni električar za sve vrste kućnih popravki i instalacija.', 2500.00),
(3, 'Vodoinstalater', 'Hitne intervencije, odgušenja i zamena cevi.', 3000.00);

-- Test usluge
INSERT INTO usluge (majstor_id, naziv_usluge, opis, cena) VALUES
(1, 'Zamena osigurača', 'Zamena starih topljivih osigurača automatskim.', 3000.00),
(1, 'Montaža lustera', 'Kačenje i povezivanje rasvete na plafonu.', 2000.00),
(2, 'Odgušenje slivnika', 'Mašinsko odgušenje odvoda u kupatilu ili kuhinji.', 4500.00);

-- Test zahtev
INSERT INTO zahtevi (klijent_id, majstor_id, opis_kvara, status) VALUES
(1, 1, 'Treba mi zamena table sa osiguračima u stanu.', 'prihvaceno');
