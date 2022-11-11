namespace LSP_Before
{
    class Document
    {
        public string Data { get; set; }
        public string Filename { get; set; }

        public virtual void Open()
        {
            // Open File
        }
        public virtual void Save()
        {
            // Save File
        }
    }



    class ReadOnlyDocument : Document
    {
        public override void Save()
        {
            throw new Exception("Can't save a read-only document");
        }
    }



    class Project
    {
        private List<Document> _documents;

        public void OpenAll()
        {
            foreach (var document in _documents)
                document.Open();
        }
        public void SaveAll()
        {
            foreach (var document in _documents)
                if (document is not ReadOnlyDocument)
                    document.Save();
        }
    }
}









namespace LSP_After
{
    class Document
    {
        public string Data { get; set; }
        public string Filename { get; set; }


        public virtual void Open()
        {
            // Open File
        }
    }



    class WritableDocument : Document
    {
        public void Save()
        {
            // Save file
        }
    }



    class Project
    {
        private List<Document> _allDocuments;
        private List<WritableDocument> _writableDocuments;



        public void OpenAll()
        {
            foreach (var document in _allDocuments)
                document.Open();

            foreach (var document in _writableDocuments)
                document.Open();
        }
        public void SaveAll()
        {
            foreach (var document in _writableDocuments)
                document.Save();
        }
    }
}