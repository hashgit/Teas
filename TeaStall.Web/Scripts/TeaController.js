function TeaCtrl($scope, TeaService) {
    $scope.Toppings = [];
    $scope.SavedOrders = [];
    $scope.TeaBases = [];
    $scope.CurrentOrder = {};
    $scope.TotalPrice = 0;

    TeaService.GetTeaBases().success(function(result) {
        $scope.TeaBases = result;
        if ($scope.TeaBases.length > 0)
            $scope.CurrentOrder.TeaBase = $scope.TeaBases[0];

        $scope.UpdatePrice();
    });

    $scope.Flavors = [];

    TeaService.GetFlavors().success(function (result) {
        $scope.Flavors = result;
    });

    TeaService.GetToppings().success(function (result) {
        $scope.CurrentOrder.Toppings = result;
        $scope.Toppings = result;
    });

    $scope.SizeFactor = {};
    $scope.SizeFactor.Small = 1;
    $scope.SizeFactor.Medium = 2;
    $scope.SizeFactor.Large = 3;

    $scope.UpdatePrice = function() {
        $scope.CurrentOrder.Price = ($scope.CurrentOrder.TeaBase.Price) * ($scope.SizeFactor[$scope.CurrentOrder.Size]);
        if ($scope.CurrentOrder.Flavor && $scope.CurrentOrder.Flavor.Price) {
            $scope.Price += $scope.CurrentOrder.Flavor.Price;
        }

        $.each($scope.CurrentOrder.Toppings, function(index, topping) {
            if (topping.IsChecked) {
                $scope.CurrentOrder.Price += topping.Price;
            }
        });
    };

    $scope.ToppingCount = function(toppings) {
        var c = 0;
        $.each(toppings, function(index, topping) {
            if (topping.IsChecked) c++;
        });

        return c;
    };

    $scope.WorkingOrder = -1;
    $scope.SaveOrder = function() {
        if ($scope.SavedOrders.length > 0 && $scope.WorkingOrder >= 0) {
            $scope.SavedOrders[$scope.WorkingOrder] = $scope.CurrentOrder;
            $scope.SavedOrders[$scope.WorkingOrder].Toppings = JSON.parse(JSON.stringify($scope.CurrentOrder.Toppings));
            $scope.WorkingOrder = -1;
        }
        else {
            $scope.SavedOrders.push($scope.CurrentOrder);
            $scope.SavedOrders[$scope.SavedOrders.length-1].Toppings = JSON.parse(JSON.stringify($scope.CurrentOrder.Toppings));
        }

        $scope.InitOrder();
    };

    $scope.EditOrder = function (index) {
        if ($scope.WorkingOrder == -1) delete $scope.CurrentOrder;
        $scope.CurrentOrder = $scope.SavedOrders[index];
        $scope.WorkingOrder = index;
    };

    $scope.DeleteOrder = function (index) {
        $scope.SavedOrders.splice(index, 1);
    };

    $scope.InitOrder = function () {
        $scope.CurrentOrder = { Price: 0, Size: "Small", TeaBase: {}, Flavor: {}, Toppings: $scope.Toppings };
        if ($scope.TeaBases.length > 0)
            $scope.CurrentOrder.TeaBase = $scope.TeaBases[0];
        $scope.UpdatePrice();
    };

    $scope.InitOrder();
    $scope.UpdateTotal = function() {
        var total = 0;
        $.each($scope.SavedOrders, function(index, order) {
            total += order.Price;
        });

        return total;
    };
}