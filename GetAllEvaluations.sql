USE [Oiga_DB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEvaluations]    Script Date: 3/6/2023 12:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllEvaluations]
    @CourseName nvarchar(200) = null,   
    @Stars nvarchar(50) = null,
	@StudentName nvarchar(200) = null,
	@Grade nvarchar(50) = null   
AS  

	Select e.id as evaluation_Id, 
			e.course_student_id as course_student_id, 
			e.stars as stars,
			e.description as description,
			e.creation_date as creation_date,
			c.name as course_name, 
			c.active as is_active_course,
			cs.grade as grade,
			(s.name + ' ' + s.last_name) as full_name

	from Evaluations as e
	left join CourseStudents as cs on e.course_student_id = cs.id
	left join Courses as c on cs.course_id = c.id
	left join Students as s on cs.student_id = s.id

	Where (@Stars is null or e.stars = cast(@Stars as int))
	and (@CourseName is null or c.name like '%' +  @CourseName + '%' )
	and (@Grade is null or e.stars = cast(@Grade as int))
	and (@StudentName is null or s.name like '%' +  @StudentName + '%' )
	and e.delete_date is null
	order by e.creation_date desc

	
