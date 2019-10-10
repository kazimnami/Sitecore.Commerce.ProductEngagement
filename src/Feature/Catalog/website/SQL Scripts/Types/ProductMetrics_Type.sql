IF TYPE_ID('[dbo].[ProductMetrics_Type]') IS NOT NULL 
BEGIN
  PRINT 'Dropping [dbo].[ProductMetrics_Type]'
  DROP TYPE [dbo].[ProductMetrics_Type];
END
GO

PRINT 'Creating [dbo].[ProductMetrics_Type]'
CREATE TYPE [dbo].[ProductMetrics_Type] AS TABLE( 
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
PRIMARY KEY CLUSTERED 
( 
	[SegmentRecordId] ASC 
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
