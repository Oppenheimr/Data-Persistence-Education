using UnityEngine.SceneManagement;

namespace UI
{
    public interface ISceneManagement<T>
    {
        void SceneTranslation(T scene);
    }
}