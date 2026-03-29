namespace AlertMedicament.Domain.Enums;

public enum AlertType
{
    LowStock = 1,        // Stock bajo
    OverStock = 2,       // Exceso de stock
    ExpiringSoon = 3     // Próximo a caducar
}