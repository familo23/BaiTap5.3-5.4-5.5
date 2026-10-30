using System.Data;
using Bai5._3.DAL;
using Bai5._3.DTO;

namespace Bai5._3.BUS;

public sealed class CafeBUS
{
    private readonly CafeDAL dal = new();

    public DataTable LoadTables() => dal.LoadTables();
    public DataTable LoadCategories() => dal.LoadCategories();
    public DataTable LoadMenu() => dal.LoadMenu();
    public DataTable LoadOrder(int tableId) => dal.LoadOrder(tableId);
    public void Pay(int tableId) => dal.Pay(tableId);
    public void DeleteMenu(int menuId) => dal.DeleteMenu(menuId);

    public void AddItem(int tableId, int menuId, int quantity)
    {
        if (quantity <= 0)
            throw new Exception("Số lượng phải lớn hơn 0.");

        dal.AddItem(tableId, menuId, quantity);
    }

    public void SaveMenu(MonAnDTO monAn)
    {
        monAn.TenMon = monAn.TenMon.Trim();

        if (string.IsNullOrWhiteSpace(monAn.TenMon))
            throw new Exception("Tên món không được để trống.");

        if (monAn.DonGia < 0)
            throw new Exception("Đơn giá không được âm.");

        dal.SaveMenu(monAn);
    }

    public void MoveTable(int currentTableId, int targetTableId)
    {
        if (currentTableId == targetTableId)
            throw new Exception("Không thể chuyển sang chính bàn hiện tại.");

        dal.MoveTable(currentTableId, targetTableId);
    }
}
