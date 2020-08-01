CREATE DATABASE DB_Candidates
GO

USE DB_Candidates
GO

CREATE TABLE TB_candidate_information(
	IN_candidate_id INT IDENTITY(1,1) PRIMARY KEY,
	VC_name VARCHAR(100),
	VC_email VARCHAR(100),
	VC_telephone VARCHAR(20)
)
GO

CREATE TABLE TB_interview_information(
	IN_interview_id INT IDENTITY(1,1) PRIMARY KEY,
	IN_candidate_id INT,
	VC_interview_type VARCHAR(100),
	DT_date_interview DATETIME,
	VC_interview_form VARCHAR(100),
	FOREIGN KEY (IN_candidate_id) 
	REFERENCES TB_candidate_information(IN_candidate_id)
)
GO