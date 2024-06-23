CREATE TABLE Gudang (
    KodeGudang SERIAL PRIMARY KEY,
    NamaGudang VARCHAR(255) NOT NULL
);

CREATE TABLE Barang (
    KodeBarang SERIAL PRIMARY KEY,
    NamaBarang VARCHAR(255) NOT NULL,
    HargaBarang NUMERIC(18, 2) NOT NULL,
    JumlahBarang INT NOT NULL,
    ExpiredBarang DATE NOT NULL,
    KodeGudang INT REFERENCES Gudang(KodeGudang)
);

CREATE INDEX idx_kodegudang ON Barang(KodeGudang);

CREATE OR REPLACE FUNCTION GetBarangList(
    page INT,
    pageSize INT,
    sortColumn TEXT,
    sortOrder TEXT
)
RETURNS TABLE (
    KodeGudang INT,
    NamaGudang VARCHAR,
    KodeBarang INT,
    NamaBarang VARCHAR,
    HargaBarang NUMERIC,
    JumlahBarang INT,
    ExpiredBarang DATE
) AS $$
BEGIN
    RETURN QUERY EXECUTE format(
        'SELECT G.KodeGudang, G.NamaGudang, B.KodeBarang, B.NamaBarang, B.HargaBarang, B.JumlahBarang, B.ExpiredBarang
        FROM Gudang G JOIN Barang B ON G.KodeGudang = B.KodeGudang
        ORDER BY %I %s
        OFFSET %s LIMIT %s',
        sortColumn, sortOrder, (page - 1) * pageSize, pageSize
    );
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION CheckExpiredBarang()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.ExpiredBarang < CURRENT_DATE THEN
        RAISE EXCEPTION 'Barang kadaluarsa ditemukan!';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER BarangAfterInsert
BEFORE INSERT ON Barang
FOR EACH ROW
EXECUTE FUNCTION CheckExpiredBarang();


