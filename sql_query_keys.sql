ALTER TABLE StatementLibrary
ADD FOREIGN KEY (НомерСтудента) REFERENCES Students(НомерСтудента);

ALTER TABLE StatementLibrary
ADD FOREIGN KEY (НомерКниги) REFERENCES Books(НомерКниги);