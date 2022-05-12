$namespace = "benchmark"

# create the namespace using kubectl
kubectl create namespace $namespace

# create the newman pod
kubectl apply -f pod.yaml -n $namespace

# wait for the newman pod to be ready
kubectl wait --for=condition=Ready -n $namespace pod/benchmark-csharp --timeout=600s

# attach to the newman pod
kubectl attach pod/benchmark-csharp -c benchmark-csharp -n $namespace