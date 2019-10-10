IF OBJECT_ID('dbo.Add_ProductMetrics_Tvp', 'p') IS NOT NULL 
BEGIN
  PRINT 'Dropping [dbo].[Add_ProductMetrics_Tvp]'
  DROP PROCEDURE [dbo].[Add_ProductMetrics_Tvp];
END
GO

PRINT 'Creating [dbo].[Add_ProductMetrics_Tvp]'
GO
CREATE PROCEDURE [dbo].[Add_ProductMetrics_Tvp]
@table [dbo].[ProductMetrics_Type] READONLY
WITH EXECUTE AS OWNER
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		MERGE [Fact_ProductMetrics] AS Target USING @table AS Source
		ON
		Target.[SegmentRecordId] = Source.[SegmentRecordId]
		WHEN MATCHED THEN
		UPDATE SET
			Target.[Visits]=(Target.[Visits]+Source.[Visits]),
			Target.[Value]=(Target.[Value]+Source.[Value]),
			Target.[ItemValue]=(Target.[ItemValue]+Source.[ItemValue]),
			Target.[MonetaryValue]=(Target.[MonetaryValue]+Source.[MonetaryValue]),
			Target.[ItemMonetaryValue]=(Target.[ItemMonetaryValue]+Source.[ItemMonetaryValue]),
			Target.[Conversions]=(Target.[Conversions]+Source.[Conversions]),
			Target.[ItemConversions]=(Target.[ItemConversions]+Source.[ItemConversions]),
			Target.[Pageviews]=(Target.[Pageviews]+Source.[Pageviews]),
			Target.[ItemPageviews]=(Target.[ItemPageviews]+Source.[ItemPageviews]),
			Target.[Bounces]=(Target.[Bounces]+Source.[Bounces]),
			Target.[TimeOnPage]=(Target.[TimeOnPage]+Source.[TimeOnPage]),
			Target.[TimeOnSite]=(Target.[TimeOnSite]+Source.[TimeOnSite]),
			Target.[OutcomeOccurrences]=(Target.[OutcomeOccurrences]+Source.[OutcomeOccurrences]),
			Target.[ItemOutcomeOccurrences]=(Target.[ItemOutcomeOccurrences]+Source.[ItemOutcomeOccurrences])
		WHEN NOT MATCHED THEN
		INSERT (
			[SegmentRecordId],
			[SegmentId],
			[Date],
			[SiteNameId],
			[DimensionKeyId],
			[Visits],
			[Value],
			[ItemValue],
			[MonetaryValue],
			[ItemMonetaryValue],
			[Conversions],
			[ItemConversions],
			[Pageviews],
			[ItemPageviews],
			[Bounces],
			[TimeOnPage],
			[TimeOnSite],
			[OutcomeOccurrences],
			[ItemOutcomeOccurrences])
		Values (
			Source.[SegmentRecordId],
			Source.[SegmentId],
			Source.[Date],
			Source.[SiteNameId],
			Source.[DimensionKeyId],
			Source.[Visits],
			Source.[Value],
			Source.[ItemValue],
			Source.[MonetaryValue],
			Source.[ItemMonetaryValue],
			Source.[Conversions],
			Source.[ItemConversions],
			Source.[Pageviews],
			Source.[ItemPageviews],
			Source.[Bounces],
			Source.[TimeOnPage],
			Source.[TimeOnSite],
			Source.[OutcomeOccurrences],
			Source.[ItemOutcomeOccurrences]);
	END TRY
	BEGIN CATCH
		DECLARE @error_number INTEGER = ERROR_NUMBER();
		DECLARE @error_severity INTEGER = ERROR_SEVERITY();
		DECLARE @error_state INTEGER = ERROR_STATE();
		DECLARE @error_message NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @error_procedure SYSNAME = ERROR_PROCEDURE();
		DECLARE @error_line INTEGER = ERROR_LINE();
		RAISERROR( N'T-SQL ERROR %d, SEVERITY %d, STATE %d, PROCEDURE %s, LINE %d, MESSAGE: %s', @error_severity, 1, @error_number, @error_severity, @error_state, @error_procedure, @error_line, @error_message ) WITH NOWAIT;
	END CATCH;
END
GO
