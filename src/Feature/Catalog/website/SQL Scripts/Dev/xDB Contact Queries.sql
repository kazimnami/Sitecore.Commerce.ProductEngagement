DECLARE @EmailAddress varchar(max) = 'magic@sitecore.net';

/* List xDB contact email addresses */
SELECT *
FROM (
  SELECT *,CONVERT(VARCHAR(MAX), [Identifier]) as DecodedIdentifier, 'Shard0' as Shard 
  FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[ContactIdentifiers]
  UNION ALL 
  SELECT *,CONVERT(VARCHAR(MAX), [Identifier]) as DecodedIdentifier, 'Shard1' as Shard
  FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[ContactIdentifiers]
) ContactIdentifiers_Unioned
WHERE Source = 'CommerceUser'

/* Get a contact id for an email address */
DECLARE @ContactId varchar(max);
SELECT @ContactId = ContactId
FROM (
  SELECT *,CONVERT(VARCHAR(MAX), [Identifier]) as DecodedIdentifier, 'Shard0' as Shard 
  FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[ContactIdentifiers]
  UNION ALL 
  SELECT *,CONVERT(VARCHAR(MAX), [Identifier]) as DecodedIdentifier, 'Shard1' as Shard
  FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[ContactIdentifiers]
) ContactIdentifiers_Unioned
WHERE DecodedIdentifier like '%' +@EmailAddress + '%'
PRINT 'Contact Id ' + @ContactId + ' for email identifier ' + @EmailAddress 

/* List contacts - contact facets */
SELECT *
FROM (	SELECT 'Shard0' as Shard, * FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[ContactFacets]
		UNION ALL 
		SELECT 'Shard1' as Shard, * FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[ContactFacets]
	) tbl
WHERE ContactId = @ContactId

/* List contacts interactions */
SELECT *
FROM (	SELECT 'Shard0' as Shard, * FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[Interactions]
		UNION ALL 
		SELECT 'Shard1' as Shard, * FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[Interactions]
	) tbl
WHERE ContactId = @ContactId

/* List contacts - interaction facets */
SELECT *
FROM (	SELECT 'Shard0' as Shard, * FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[InteractionFacets]
		UNION ALL 
		SELECT 'Shard1' as Shard, * FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[InteractionFacets]
	) tbl
WHERE ContactId = @ContactId

/* List contacts interactions - staging */
SELECT *
FROM (	SELECT 'Shard0' as Shard, * FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[Interactions_Staging]
		UNION ALL 
		SELECT 'Shard1' as Shard, * FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[Interactions_Staging]
	) tbl
WHERE ContactId = @ContactId

/* List contacts - interaction facets - staging */
SELECT *
FROM (	SELECT 'Shard0' as Shard, * FROM [habitathome_Xdb.Collection.Shard0].[xdb_collection].[InteractionFacets_Staging]
		UNION ALL 
		SELECT 'Shard1' as Shard, * FROM [habitathome_Xdb.Collection.Shard1].[xdb_collection].[InteractionFacets_Staging]
	) tbl
WHERE ContactId = @ContactId
