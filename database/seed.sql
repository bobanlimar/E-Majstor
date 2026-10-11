USE e_majstor;

INSERT INTO gradovi (naziv) VALUES 
('Beograd'), ('Novi Sad'), ('Niš'), ('Kragujevac');

INSERT INTO kategorije (naziv) VALUES 
('Električar'), ('Vodoinstalater'), ('Moleri i fasaderi'), ('Klimatizacija');

INSERT INTO users (ime_prezime, email, sifra_hash, telefon, grad_id, uloga) VALUES
('Marko Marković', 'marko@gmail.com', 'hash_sifra_1', '0641112223', 1, 'klijent'),
('Jovana Jovanić', 'jovana@gmail.com', 'hash_sifra_2', '0619988776', 1, 'klijent'),
('Petar Petrović', 'petar.majstor@gmail.com', 'hash_sifra_3', '0633334445', 1, 'majstor'),
('Nikola Nikolić', 'nikola.vodoinstalater@gmail.com', 'hash_sifra_4', '0655556667', 2, 'majstor'),
('Milan Milanović', 'milan.moler@gmail.com', 'hash_sifra_5', '0621234567', 1, 'majstor');

INSERT INTO majstori (user_id, kategorija_id, opis, cena_po_satu, ocena_prosek) VALUES
(3, 1, 'Iskusni električar za sve vrste kućnih popravki i instalacija.', 2500.00, 4.8),
(4, 2, 'Hitne intervencije, odgušenja i zamena cevi.', 3000.00, 5.0),
(5, 3, 'Gletovanje, krečenje i dekorativne tehnike.', 2000.00, 4.5);

INSERT INTO usluge (majstor_id, naziv_usluge, opis, cena) VALUES
(1, 'Zamena osigurača', 'Zamena starih topljivih osigurača automatskim.', 3000.00),
(1, 'Montaža lustera i rasvete', 'Kačenje i povezivanje rasvete na plafonu i zidovima.', 2000.00),
(2, 'Odgušenje slivnika', 'Mašinsko odgušenje odvoda u kupatilu ili kuhinji.', 4500.00),
(2, 'Zamena baterije/slavine', 'Montaža nove slavine u kuhinji ili kupatilu.', 2500.00),
(3, 'Krečenje prostorije', 'Priprema zidova i krečenje u dva sloja po m2.', 1500.00);

INSERT INTO zahtevi (klijent_id, majstor_id, usluga_id, opis_kvara, status) VALUES
(1, 3, 1, 'Treba mi zamena table sa osiguračima u stanu.', 'prihvaceno'),
(2, 4, 3, 'Zapušila se sudopera u kuhinji, voda ne prolazi.', 'zavrseno');

INSERT INTO ocene (zahtev_id, klijent_id, majstor_id, ocena, komentar) VALUES
(2, 2, 4, 5, 'Odlična i brza usluga, rešio problem u roku od pola sata!');

INSERT INTO poruke (posiljalac_id, primalac_id, sadrzaj) VALUES
(1, 3, 'Zdravo Petre, kada biste mogli da dođete da pogledate tablu sa osiguračima?'),
(3, 1, 'Zdravo Marko, mogu sutra oko 14h.');

