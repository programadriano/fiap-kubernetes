using k8s;
using KubernetesRESTful.Models;

namespace KubernetesRESTful.Infra
{
    public class KubernetesLib
    {
        public IList<Events> GetEvents()
        {
            var eventsLits = new List<Events>();

            string apiServerUrl = "http://127.0.0.1:8001";

            string ns = "default";

            var config = new KubernetesClientConfiguration { Host = apiServerUrl };


            var client = new Kubernetes(config);


            var events = client.ListNamespacedEvent(ns).Items;


            foreach (var ev in events)
            {
                var eventK8S = new Events();
                eventK8S.PodName = ev.Metadata.Name;
                eventK8S.Namespace = ev.Metadata.NamespaceProperty;
                eventK8S.Type = ev.Type;
                eventK8S.Reason = ev.Reason;
                eventK8S.Message = ev.Message;
                eventK8S.LastTimestamp = ev.LastTimestamp;

                eventsLits.Add(eventK8S);
            }

            return eventsLits;
        }
    }
}
