public interface ISecretManager
{
    bool Put(string key, string value); 
    
    string Get(string key);
    
    bool Delete(string key);
}