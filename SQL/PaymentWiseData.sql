WITH CTE AS (
    SELECT
        *,
        ROW_NUMBER() OVER (PARTITION BY PONo, PBNo ORDER BY ID) AS rn,
        SUM(AdvancePay) OVER (PARTITION BY PONo, PBNo ORDER BY ID ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING) AS PrevAdvanceSum
    FROM Payments
)
SELECT
    ID,
    PaymentID,
    PONo,
    PBNo,
    CASE 
        WHEN rn = 1 THEN NetPayable
        ELSE NetPayable - ISNULL(PrevAdvanceSum, 0)
    END AS NetPayable,
    AdvancePay,
    CASE
        WHEN rn = 1 THEN NetPaid
        ELSE (NetPayable - ISNULL(PrevAdvanceSum, 0)) - AdvancePay
    END AS NetPaid
FROM CTE
--WHERE PONo = 'PO005' AND PBNo = 'PB005'
ORDER BY ID;


SELECT
    MIN(ID) AS ID,
    MIN(PaymentID) AS PaymentID,
    PONo,
    PBNo,
    MAX(NetPayable) AS NetPayable,   -- Or SUM(NetPayable) if you want total
    SUM(AdvancePay) AS AdvancePay,
    MAX(NetPayable) - SUM(AdvancePay) AS NetPaid
FROM Payments
GROUP BY PONo, PBNo
ORDER BY ID;
