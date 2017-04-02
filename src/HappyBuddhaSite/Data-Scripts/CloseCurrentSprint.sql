Create	Procedure	System.CloseCurrentSprint
As	Begin

	Insert	dbo.SelfReviewSummary	(
		Id
	,	CompanyRate
	,	OveralRate
	,	SelfRate
	,	SprintId
	,	TeamRate
	,	UserId
	,	TeamId
	,	SelfReviewId
	)

	Select	NewId()
	,	SR.CompanyRate
	,	(
			SR.CompanyRate
		+	SR.TasksRate
		+	SR.SelfInvestmentRate
		+	SR.TeamRate
		+	SR.WorkRate
		)
	/	5
	,	SR.SelfInvestmentRate
	,	T.CurrentSprintId
	,	SR.TeamRate
	,	U.Id
	,	T.Id
	,	SR.Id
		From	dbo.[AspNetUsers]	As	U
		Inner	Join
			dbo.Team		As	T
		On	U.SelectedTeamId	=	T.Id
		Inner	Join
			dbo.SelfReview		As	SR
		On	SR.UserId		=	U.Id
		And	SR.CurrentSprintId	=	T.CurrentSprintId
		Left	Outer	Join
			dbo.SelfReviewSummary	As	SRS
		On	SRS.SelfReviewId	=	SR.Id
		Where	SRS.Id			Is	Null
		--And	SR.TeamId		=	T.Id
		;

End;