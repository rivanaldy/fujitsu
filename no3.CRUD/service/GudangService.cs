using System.Collections.Generic;

public class GudangService
{
    private List<Gudang> gudangs = new List<Gudang>();
    private int nextId = 1;

    public void AddGudang(Gudang gudang)
    {
        gudang.Id = nextId++;
        gudangs.Add(gudang);
    }

    public List<Gudang> GetAllGudangs()
    {
        return gudangs;
    }

    public Gudang GetGudangById(int id)
    {
        return gudangs.Find(g => g.Id == id);
    }

    public void UpdateGudang(Gudang updatedGudang)
    {
        int index = gudangs.FindIndex(g => g.Id == updatedGudang.Id);
        if (index != -1)
        {
            gudangs[index] = updatedGudang;
        }
    }

    public void DeleteGudang(int id)
    {
        gudangs.RemoveAll(g => g.Id == id);
    }
}
