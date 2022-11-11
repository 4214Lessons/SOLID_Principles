namespace ISP_Before
{
    interface ICloudProvide
    {
        void StoreFile(string name);
        void GetFile(string name);
        void CreteServer(string region);
        void ListServer(string region);
        void GetCDNAddress();
    }



    class Amazon : ICloudProvide
    {
        public void StoreFile(string name)
        {
            // do smth
        }

        public void GetFile(string name)
        {
            // do smth
        }

        public void CreteServer(string region)
        {
            // do smth
        }

        public void ListServer(string region)
        {
            // do smth
        }

        public void GetCDNAddress()
        {
            // do smth
        }
    }




    class Dropbox : ICloudProvide
    {
        public void StoreFile(string name)
        {
            // do smth
        }

        public void GetFile(string name)
        {
            // do smth
        }

        public void CreteServer(string region)
        {
            throw new NotImplementedException();
        }

        public void ListServer(string region)
        {
            throw new NotImplementedException();
        }

        public void GetCDNAddress()
        {
            throw new NotImplementedException();
        }
    }
}












namespace ISP_After
{
    interface ICloudHostingProvide
    {
        void CreteServer(string region);
        void ListServer(string region);
    }

    interface ICDNProvide
    {
        void GetCDNAddress();
    }

    interface ICloudStorageProvide
    {
        void StoreFile(string name);
        void GetFile(string name);
    }





    class Amazon : ICDNProvide, ICloudStorageProvide, ICloudHostingProvide
    {
        public void StoreFile(string name)
        {
            // do smth
        }

        public void GetFile(string name)
        {
            // do smth
        }

        public void CreteServer(string region)
        {
            // do smth
        }

        public void ListServer(string region)
        {
            // do smth
        }

        public void GetCDNAddress()
        {
            // do smth
        }
    }


    class Dropbox : ICloudStorageProvide
    {
        public void StoreFile(string name)
        {
            // do smth
        }
        public void GetFile(string name)
        {
            // do smth
        }
    }
}