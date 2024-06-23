using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static GudangService gudangService = new GudangService();
    static BarangService barangService = new BarangService();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Tampilkan Daftar Gudang");
            Console.WriteLine("2. Tampilkan Daftar Barang");
            Console.WriteLine("3. Tambah Gudang");
            Console.WriteLine("4. Tambah Barang");
            Console.WriteLine("5. Update Gudang");
            Console.WriteLine("6. Update Barang");
            Console.WriteLine("7. Hapus Gudang");
            Console.WriteLine("8. Hapus Barang");
            Console.WriteLine("9. Keluar");
            Console.Write("Pilih menu (1-9): ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    TampilkanDaftarGudang();
                    break;
                case "2":
                    TampilkanDaftarBarang();
                    break;
                case "3":
                    TambahGudang();
                    break;
                case "4":
                    TambahBarang();
                    break;
                case "5":
                    UpdateGudang();
                    break;
                case "6":
                    UpdateBarang();
                    break;
                case "7":
                    HapusGudang();
                    break;
                case "8":
                    HapusBarang();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan pilih menu 1-9.");
                    break;
            }

            Console.WriteLine("\nTekan Enter untuk melanjutkan");
            Console.ReadLine();
        }
    }

    static void TampilkanDaftarGudang()
    {
        Console.WriteLine("\n=== DAFTAR GUDANG ===");
        var gudangs = gudangService.GetAllGudangs();
        foreach (var gudang in gudangs)
        {
            Console.WriteLine($"ID: {gudang.Id}, Nama: {gudang.NamaGudang}");
        }
    }

    static void TampilkanDaftarBarang()
    {
        Console.WriteLine("\n=== DAFTAR BARANG ===");
        var barangs = barangService.GetAllBarangs();
        foreach (var barang in barangs)
        {
            Console.WriteLine($"ID: {barang.Id}, Nama: {barang.NamaBarang}, Harga: {barang.HargaBarang}");
        }
    }

    static void TambahGudang()
    {
        Console.Write("\nMasukkan nama gudang baru: ");
        string namaGudang = Console.ReadLine();
        gudangService.AddGudang(new Gudang { NamaGudang = namaGudang });
        Console.WriteLine("Gudang berhasil ditambahkan.");
    }

    static void TambahBarang()
    {
        Console.Write("\nMasukkan nama barang baru: ");
        string namaBarang = Console.ReadLine();
        Console.Write("Masukkan harga barang: ");
        decimal hargaBarang = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Masukkan jumlah barang: ");
        int jumlahBarang = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan tanggal kadaluarsa barang (yyyy-MM-dd): ");
        DateTime expiredBarang = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Masukkan kode gudang: ");
        int kodeGudang = Convert.ToInt32(Console.ReadLine());

        barangService.AddBarang(new Barang
        {
            NamaBarang = namaBarang,
            HargaBarang = hargaBarang,
            JumlahBarang = jumlahBarang,
            ExpiredBarang = expiredBarang,
            KodeGudang = kodeGudang
        });

        Console.WriteLine("Barang berhasil ditambahkan.");
    }

    static void UpdateGudang()
    {
        Console.Write("\nMasukkan ID gudang yang ingin diperbarui: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var gudang = gudangService.GetGudangById(id);
        if (gudang == null)
        {
            Console.WriteLine("Gudang tidak ditemukan.");
            return;
        }

        Console.Write("Masukkan nama gudang baru: ");
        string namaGudang = Console.ReadLine();

        gudang.NamaGudang = namaGudang;
        gudangService.UpdateGudang(gudang);
        Console.WriteLine("Gudang berhasil diperbarui.");
    }

    static void UpdateBarang()
    {
        Console.Write("\nMasukkan ID barang yang ingin diperbarui: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var barang = barangService.GetBarangById(id);
        if (barang == null)
        {
            Console.WriteLine("Barang tidak ditemukan.");
            return;
        }

        Console.Write("Masukkan nama barang baru: ");
        string namaBarang = Console.ReadLine();
        Console.Write("Masukkan harga barang baru: ");
        decimal hargaBarang = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Masukkan jumlah barang baru: ");
        int jumlahBarang = Convert.ToInt32(Console.ReadLine());
        Console.Write("Masukkan tanggal kadaluarsa barang baru (yyyy-MM-dd): ");
        DateTime expiredBarang = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Masukkan kode gudang baru: ");
        int kodeGudang = Convert.ToInt32(Console.ReadLine());

        barang.NamaBarang = namaBarang;
        barang.HargaBarang = hargaBarang;
        barang.JumlahBarang = jumlahBarang;
        barang.ExpiredBarang = expiredBarang;
        barang.KodeGudang = kodeGudang;

        barangService.UpdateBarang(barang);
        Console.WriteLine("Barang berhasil diperbarui.");
    }

    static void HapusGudang()
    {
        Console.Write("\nMasukkan ID gudang yang ingin dihapus: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var gudang = gudangService.GetGudangById(id);
        if (gudang == null)
        {
            Console.WriteLine("Gudang tidak ditemukan.");
            return;
        }

        gudangService.DeleteGudang(id);
        Console.WriteLine("Gudang berhasil dihapus.");
    }

    static void HapusBarang()
    {
        Console.Write("\nMasukkan ID barang yang ingin dihapus: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var barang = barangService.GetBarangById(id);
        if (barang == null)
        {
            Console.WriteLine("Barang tidak ditemukan.");
            return;
        }

        barangService.DeleteBarang(id);
        Console.WriteLine("Barang berhasil dihapus.");
    }
}
