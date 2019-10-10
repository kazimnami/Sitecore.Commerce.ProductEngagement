IF OBJECT_ID('[dbo].[Fact_ProductMetrics]', 'U') IS NOT NULL 
BEGIN
  PRINT 'Dropping [dbo].[Fact_ProductMetrics]'
  DROP TABLE [dbo].[Fact_ProductMetrics];
END
GO

PRINT 'Creating [dbo].[Fact_ProductMetrics]'
CREATE TABLE [dbo].[Fact_ProductMetrics]( 
	-- Mandatory Columns 
	[SegmentRecordId] [bigint] NOT NULL, 
	[SegmentId] [uniqueidentifier] NOT NULL, 
	[Date] [smalldatetime] NOT NULL, 
	[SiteNameId] [int] NOT NULL, 
	[DimensionKeyId] [bigint] NOT NULL, 
	-- Dimension specific metric columns 
	[Visits] [int] NOT NULL, 
	[Value] [int] NOT NULL, 
	[ItemValue] [int] NOT NULL, 
	[MonetaryValue] [money] NOT NULL, 
	[ItemMonetaryValue] [money] NOT NULL, 
	[Conversions] [int] NOT NULL, 
	[ItemConversions] [int] NOT NULL, 
	[Pageviews] [int] NOT NULL,
	[ItemPageviews] [int] NOT NULL,
	[Bounces] [int] NOT NULL, 
	[TimeOnPage] [int] NOT NULL,
	[TimeOnSite] [int] NOT NULL, 
	[OutcomeOccurrences] [int] NOT NULL, 
	[ItemOutcomeOccurrences] [int] NOT NULL, 
CONSTRAINT [PK_Fact_OutcomeMetrics_1] PRIMARY KEY CLUSTERED 
( 
	[SegmentRecordId] ASC 
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] 
) ON [PRIMARY]
GO

