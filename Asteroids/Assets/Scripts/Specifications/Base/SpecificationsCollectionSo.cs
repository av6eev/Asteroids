using UnityEngine;

namespace Specifications.Base
{
    [CreateAssetMenu(menuName = "Create Specifications Collection/New Specifications Collection", fileName = "SpecificationsCollection", order = 50)]
    public class SpecificationsCollectionSo : ScriptableObject
    {
        public SpecificationsCollection Collection;
    }
}