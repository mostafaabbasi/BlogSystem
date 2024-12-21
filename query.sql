WITH DateRange AS (
    SELECT DISTINCT CAST(CreatedAt AS DATE) AS PostDate
    FROM Posts WITH (NOLOCK)
)
SELECT 
    d.PostDate,
    ISNULL(COUNT(DISTINCT p.Id), 0) AS PostCount
FROM DateRange d
LEFT JOIN (
    SELECT 
        p.Id,
        CAST(p.CreatedAt AS DATE) AS PostDate
    FROM Posts p WITH (NOLOCK)
    WHERE LEN(p.Content) > 100
        AND EXISTS (
            SELECT 1 
            FROM PostTags pt WITH (NOLOCK)
            WHERE pt.PostId = p.Id
        )
) p ON d.PostDate = p.PostDate
GROUP BY d.PostDate
OPTION (RECOMPILE);