$namespace = "benchmark"

# create the namespace using kubectl
kubectl create namespace $namespace

# create the newman pod
kubectl apply -f pod.yaml -n $namespace
