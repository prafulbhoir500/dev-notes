# Audit Table

```sql
CREATE TABLE users_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    action NVARCHAR(10),
    changed_by NVARCHAR(128),
    changed_at DATETIME,
    original_id INT,
    old_values NVARCHAR(MAX),
    new_values NVARCHAR(MAX)
);
```

# Add Trigger

```sql
CREATE TRIGGER trg_audit_users
ON users
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERT
    INSERT INTO users_audit (action, changed_by, changed_at, original_id, new_values)
    SELECT 
        'INSERT',
        ISNULL(i.CreatedBy, SYSTEM_USER),
        GETDATE(),
        i.id,
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM INSERTED i
    WHERE NOT EXISTS (SELECT 1 FROM DELETED WHERE DELETED.id = i.id);

    -- UPDATE
    INSERT INTO users_audit (action, changed_by, changed_at, original_id, old_values, new_values)
    SELECT 
        'UPDATE',
        ISNULL(i.RevisedBy, SYSTEM_USER),
        GETDATE(),
        i.id,
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM INSERTED i
    INNER JOIN DELETED d ON i.id = d.id;

    -- DELETE
    INSERT INTO users_audit (action, changed_by, changed_at, original_id, old_values)
    SELECT 
        'DELETE',
        ISNULL(d.RevisedBy, SYSTEM_USER),
        GETDATE(),
        d.id,
        (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM DELETED d
    WHERE NOT EXISTS (SELECT 1 FROM INSERTED WHERE INSERTED.id = d.id);
END;
```
