# Wild West Cepelinai – README

## Apžvalga

Tai 2D veiksmo žaidimas, skirtas vieno arba dviejų žaidėjų kovoms su teminiais lygiais, spalvingais personažais ir greitu tempu. Žaidėjai gali pasirinkti režimą, personalizuoti veikėjus ir kautis trijuose skirtinguose lygiuose.

---

## Instaliacija

Vartotojas gali paleisti žaidimą atsidaręs **Unity** projektą ir pasirinkti ir eiti į File -> Build and Run. Turėtų sėkmingai atsidaryti žaidimo langas, kuriame galima žaisti Wild West Cepelinai.

---

## Žaidimo Struktūra ir Eiga

### 1. Pagrindinis Meniu

Paleidus žaidimą, pasirodo **pagrindinis meniu**, kuriame yra keturi mygtukai:
- `1 Player` – žaidimas prieš kompiuterį.
- `2 Players` – žaidimas dviese.
- `Options` – nustatymų langas.
- `Quit` – išeiti iš žaidimo.

Kiekvienas mygtukas nukreipia į atitinkamą sceną, kuriai priskirta savo klasė ir metodai.

---

### 2. Nustatymų Langas (Options)

Čia žaidėjas gali:
- Reguliuoti **foninės muzikos garsumą**
- Reguliuoti **garso efektų garsumą**

Pakeitimai taikomi iš karto ir galioja viso žaidimo metu.

---

### 3. Veikėjo Personalizavimas

Pasirinkus režimą, žaidėjas nukreipiamas į **aprangos pasirinkimo** langą, kur gali:
- Pasirinkti **kepurę** ir **rūbus**
- Pasirinkti **personažo spalvą**

Pasirinkimai išsaugomi ir taikomi žaidimo metu.

---

### 4. Lygių Pasirinkimas

Toliau žaidėjas gali rinktis vieną iš trijų lygių:
- **Gedimino pilis** – lietuviška tematika su cepelinais ir cepelinų bazūka.
- **Gravitacija** – kosmoso aplinka be gravitacijos.
- **Platformos** – platformų lygis su lazerių ginklais ir judančiomis platformomis.

---

### 5. Žaidimo Mechanika

Prasidėjus lygiui:
- Rodo **3 sekundžių atgalinį skaičiavimą** su valdymo instrukcijomis.
- Po atgalinio skaičiavimo aktyvuojamas judėjimas ir šaudymas.

#### Valdymas

**1 Žaidėjas:**
- Judėjimas: `W`, `A`, `S`, `D`
- Šaudymas: `Ctrl`

**2 Žaidėjas:**
- Judėjimas: Rodyklių klavišai
- Šaudymas: `E`

Kiekviename lygyje rodomos **gyvybių juostos**, o viršutiniame dešiniajame kampe yra **Options** mygtukas, leidžiantis sustabdyti, iš naujo paleisti ar išeiti iš žaidimo.

---

### 6. Žaidimo Pabaigos Langas

Pasibaigus žaidimui:
- Pasirodo **Game Over** langas.
- Parodomas **laimėtojas** ir **surinkti taškai**.
- Galima:
  - **Perkrauti** lygį
  - **Grįžti** į pagrindinį meniu
  - **Išeiti** iš žaidimo

---

## Lygių Aprašymas

### Gedimino pilis
- Aplinka: Vilnius, Lietuva
- Vaizdai: Gedimino bokštas, skraidantys cepelinai
- Ginklas: Cepelinų bazūka

### Gravitacija
- Aplinka: Kosmosas
- Mechanika: Maža gravitacija, aukšti šuoliai
- Ginklas: Pistoletai

### Platformos
- Aplinka: Kosminė erdvė
- Mechanika: Judančios platformos, padidintas sudėtingumas
- Ginklas: Lazeris

---

## Architektūros Apžvalga

- Kiekviena **scena** turi atskirą klasę, kuri tvarko vaizdavimą ir vartotojo įvestį.
- **Meniu mygtukai** per įvykių funkcijas nukreipia į kitas scenas.
- Personalizavimo ir nustatymų duomenys išsaugomi ir taikomi žaidimo metu.
- Žaidimo logika apima:
  - Atgalinį skaičiavimą
  - Žaidėjų judėjimą ir šaudymą
  - Žaidimo būsenų perėjimus (aktyvus, pauzė, pabaiga)

---

## Pastabos

- Personažo išvaizda **turi būti** pasirinkta prieš pradedant žaidimą.
- Vieno žaidėjo režime žaidžiama prieš AI.

---

