CREATE DATABASE IF NOT EXISTS e_majstor;
USE e_majstor;

-- 1. Korisnici (klijenti i majstori)
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ime_prezime VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    sifra_hash VARCHAR(255) NOT NULL,
    telefon VARCHAR(20),
    grad VARCHAR(50),
    uloga ENUM('klijent', 'majstor') DEFAULT 'klijent',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 2. Profil majstora
CREATE TABLE majstori (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    kategorija VARCHAR(50) NOT NULL,
    opis TEXT,
    cena_po_satu DECIMAL(10, 2),
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

-- 3. Usluge koje majstori nude
CREATE TABLE usluge (
    id INT AUTO_INCREMENT PRIMARY KEY,
    majstor_id INT NOT NULL,
    naziv_usluge VARCHAR(100) NOT NULL,
    opis TEXT,
    cena DECIMAL(10, 2),
    FOREIGN KEY (majstor_id) REFERENCES majstori(id) ON DELETE CASCADE
);

-- 4. Zahtevi za usluge
CREATE TABLE zahtevi (
    id INT AUTO_INCREMENT PRIMARY KEY,
    klijent_id INT NOT NULL,
    majstor_id INT NOT NULL,
    opis_kvara TEXT NOT NULL,
    status ENUM('na_cekanju', 'prihvaceno', 'odbijeno', 'zavrseno') DEFAULT 'na_cekanju',
    datum_zahteva TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (klijent_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (majstor_id) REFERENCES users(id) ON DELETE CASCADE
);

-- 5. Recenzije i ocene
CREATE TABLE ocene (
    id INT AUTO_INCREMENT PRIMARY KEY,
    zahtev_id INT UNIQUE NOT NULL,
    klijent_id INT NOT NULL,
    majstor_id INT NOT NULL,
    ocena INT CHECK (ocena BETWEEN 1 AND 5),
    komentar TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (zahtev_id) REFERENCES zahtevi(id) ON DELETE CASCADE,
    FOREIGN KEY (klijent_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (majstor_id) REFERENCES users(id) ON DELETE CASCADE
);

-- 6. Poruke / Obaveštenja
CREATE TABLE poruke (
    id INT AUTO_INCREMENT PRIMARY KEY,
    posiljalac_id INT NOT NULL,
    primalac_id INT NOT NULL,
    tekst_poruke TEXT NOT NULL,
    poslato_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (posiljalac_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (primalac_id) REFERENCES users(id) ON DELETE CASCADE
);
