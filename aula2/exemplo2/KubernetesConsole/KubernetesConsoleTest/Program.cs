using k8s;
using k8s.Models;

// Set the Kubernetes API server URL
string apiServerUrl = "http://127.0.0.1:8001";

// Set the namespace to retrieve events from
string ns = "default";

// Create a Kubernetes client configuration with the host URL
var config = new KubernetesClientConfiguration { Host = apiServerUrl };

// Create a Kubernetes client using the configuration
var client = new Kubernetes(config);

// Get the list of all events in the specified namespace
var events = client.ListNamespacedEvent(ns).Items;

// Loop through each event and print its details
foreach (var ev in events)
{
    Console.WriteLine($"Name: {ev.Metadata.Name}, Namespace: {ev.Metadata.NamespaceProperty}");
    Console.WriteLine($"Type: {ev.Type}, Reason: {ev.Reason}, Message: {ev.Message}");
    Console.WriteLine($"Last Timestamp: {ev.LastTimestamp}");
}

Console.WriteLine();

