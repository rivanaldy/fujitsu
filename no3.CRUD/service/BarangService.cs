using System;
using System.Collections.Generic;

public class BarangService
{
    private List<Barang> barangs = new List<Barang>();
    private int nextId = 1;

    public void AddBarang(Barang barang)
    {
        barang.Id = nextId++;
        barangs.Add(barang);
    }

    public List<Barang> GetAllBarangs()
    {
        return barangs;
    }

    public Barang GetBarangById(int id)
    {
        return barangs.Find(b => b.Id == id);
    }

    public void UpdateBarang(Barang updatedBarang)
    {
        int index = barangs.FindIndex(b => b.Id == updatedBarang.Id);
        if (index != -1)
        {
            barangs[index] = updatedBarang;
        }
    }

    public void DeleteBarang(int id)
    {
        barangs.RemoveAll(b => b.Id == id);
    }
}