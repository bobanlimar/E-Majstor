CREATE DATABASE IF NOT EXISTS e_majstor;
USE e_majstor;

CREATE TABLE IF NOT EXISTS gradovi (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naziv VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS kategorije (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naziv VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ime_prezime VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    sifra_hash VARCHAR(255) NOT NULL,
    telefon VARCHAR(30),
    grad_id INT,
    uloga ENUM('klijent', 'majstor', 'admin') DEFAULT 'klijent',
    kreiran_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (grad_id) REFERENCES gradovi(id) ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS majstori (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    kategorija_id INT,
    opis TEXT,
    cena_po_satu DECIMAL(10, 2) DEFAULT 0.00,
    ocena_prosek DECIMAL(3, 2) DEFAULT 0.00,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (kategorija_id) REFERENCES kategorije(id) ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS usluge (
    id INT AUTO_INCREMENT PRIMARY KEY,
    majstor_id INT NOT NULL,
    naziv_usluge VARCHAR(150) NOT NULL,
    opis TEXT,
    cena DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (majstor_id) REFERENCES majstori(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS zahtevi (
    id INT AUTO_INCREMENT PRIMARY KEY,
    klijent_id INT NOT NULL,
    majstor_id INT NOT NULL,
    usluga_id INT,
    opis_kvara TEXT NOT NULL,
    status ENUM('na_cekanju', 'prihvaceno', 'odbijeno', 'zavrseno') DEFAULT 'na_cekanju',
    kreiran_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (klijent_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (majstor_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (usluga_id) REFERENCES usluge(id) ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS ocene (
    id INT AUTO_INCREMENT PRIMARY KEY,
    zahtev_id INT UNIQUE NOT NULL,
    klijent_id INT NOT NULL,
    majstor_id INT NOT NULL,
    ocena INT CHECK (ocena BETWEEN 1 AND 5),
    komentar TEXT,
    kreiran_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (zahtev_id) REFERENCES zahtevi(id) ON DELETE CASCADE,
    FOREIGN KEY (klijent_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (majstor_id) REFERENCES users(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS poruke (
    id INT AUTO_INCREMENT PRIMARY KEY,
    posiljalac_id INT NOT NULL,
    primalac_id INT NOT NULL,
    sadrzaj TEXT NOT NULL,
    poslato_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (posiljalac_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (primalac_id) REFERENCES users(id) ON DELETE CASCADE
);

